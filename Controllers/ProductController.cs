using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using X.PagedList;
using improweb2022_02.Helpers;
using Dapper;
using System.Data;
using System.Text.Json;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private improwebContext _db = new improwebContext();
        private IConfiguration _configuration;
        private readonly DapperContext _dbx;
        public ProductController(improwebContext db, DapperContext dbx, IConfiguration configuration)
        {
            _db = db;
            _dbx = dbx;
            _configuration = configuration;
        }

        [Route("details/{id}")]
        public IActionResult Details(Int64 id)
        {
            var product = _db.Products.Find(id);
            var featuredPhoto = /*product.ProductImagesx.SingleOrDefault(p => p.Status && p.Featured)*/product.ImgURL;
            var OtherImages = product.ProductImagesx.Where(p => p.ProdID == id).ToList();
            
            var _branchStock = new List<StockCountModel>();
            _branchStock = GetBranchStock(product.ProdID);

            var Features = product.Features.ToList();
            var Specifications = product.Specifications.ToList();
            var reviews = product.ReviewProducts.Where(rs => rs.ReviewStatusID == 2).ToList();
            //var stockCount = getStockCount(id);

            ViewBag.Product = product;
            //ViewBag.StockCount = stockCount;
            ViewBag.FeaturedPhoto = featuredPhoto == null ? "~/products/NoPic.jpg" : /*featuredPhoto.Name*/featuredPhoto;
            ViewBag.BranchStock = _branchStock;
            //ViewBag.FeaturedPhotoID = featuredPhoto.ProdImageID;
            ViewBag.OtherPhoto = OtherImages;
            ViewBag.Features = Features;
            ViewBag.Specifications = Specifications;
            ViewBag.ReviewProducts = reviews;


            var relatedProducts = _db.Products.Where(p => p.GroupName == product.GroupName && p.ProdID != product.ProdID && p.Active).ToList();
            //var relatedFeaturedPhoto = relatedProducts.product.SingleOrDefault(p => p.Status && p.Featured);
            ViewBag.RelatedProducts = relatedProducts;

            return View("Details");
        }

        [Route("category/{id}")]
        public IActionResult Category(Int64 id, int? page)
        {
            var pageNumber = page ?? 1;
            var category = _db.Categories.Find(id);
            ViewBag.Category = category;
            ViewBag.CountProducts = category.Products.Count(p => p.Active);
            ViewBag.Products = category.Products.Where(p => p.Active).ToList().ToPagedList(pageNumber, 3);
            ViewBag.SubCategory = _db.Categories.Where(c => c.ParentId == id);
            ViewBag.Manufacturer = _db.Manufacturers.OrderBy(m => m.ManufacturerName)/*.Where(m => m.Status)*/;

            return View("Category");
        }
        
        [Route("category/{categoryName}")]
        public IActionResult Category(string categoryName, int? page)
        {
            var pageNumber = page ?? 1;
            var category = _db.ProductGroups.Where(c => c.GroupName == categoryName && c.Locked == true).OrderBy(c => c.GroupName).FirstOrDefault();
            ViewBag.Category = category;
            var products = _db.Products.Where(p => p.GroupName == categoryName && p.Active == true && p.OutputMe==true).OrderBy(p => p.ProdID).ToList();
            ViewBag.CountProducts = products.Count(p => p.Active);
            ViewBag.Products = products.Where(p => p.Active).ToList().ToPagedList(pageNumber, 3);
            //ViewBag.SubCategory = _db.Categories.Where(c => c.ParentId == id);
            ViewBag.Manufacturer = _db.Manufacturers.OrderBy(m => m.ManufacturerName)/*.Where(m => m.Status)*/;

            return View("Category");
        }

        [Route("brand/{id}")]
        public IActionResult Brand(Int64 id, int? page)
        {
            var pageNumber = page ?? 1;
            var brands = _db.Manufacturers.Find(id);
            ViewBag.brands = brands;
            ViewBag.CountProducts = brands.Products.Count(p => p.Active);
            ViewBag.Products = brands.Products.Where(p => p.Active).ToList().ToPagedList(pageNumber, 3);
            //ViewBag.SubCategory = _db.Categories.Where(c => c.ParentId == id);
            ViewBag.Manufacturer = _db.Manufacturers.OrderBy(m => m.ManufacturerName)/*.Where(m => m.Status)*/;

            return View("Brand");
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search(string keyword, long search_param, int? page)
        {
            var pageNumber = page ?? 1;


            #region Search Using Category Table
            /*var category = _db.Categories.Find(search_param);
            ViewBag.Category = category;
            ViewBag.SubCategory = _db.Categories.Where(c => c.ParentId == search_param);
            ViewBag.Manufacturer = _db.Manufacturers.OrderBy(m => m.ManufacturerName);
            var products = _db.Products.Where(p => p.ProductName.Contains(keyword) && p.CategoryID == search_param && p.Active).ToList();           
            ViewBag.keyword = keyword;
            ViewBag.CountProducts = products.Count(p => p.Active);
            ViewBag.Products = products.ToPagedList(pageNumber, 6);*/
            #endregion

            #region improWEB Categories
            var category = _db.ProductGroupHeads.Find(search_param);
            ViewBag.Category = category;
            ViewBag.SubCategory = _db.ProdGroupLinks.Where(c => c.GroupHeadID == search_param);
            ViewBag.Manufacturer = _db.Manufacturers.OrderBy(m => m.ManufacturerName);
            var products = _db.Products.Where(p => p.ProductName.Contains(keyword) /*&& p.GroupName == search_param*/ && p.Active).ToList();
            ViewBag.keyword = keyword;
            ViewBag.CountProducts = products.Count(p => p.Active);
            ViewBag.Products = products.ToPagedList(pageNumber, 6);
            #endregion

            return View("Search");
        }
       
        [HttpGet]
        [Route("search2")]
        public IActionResult  Search2(long search_param, string keyword)
        {        
            var _searchModel = new SearchViewModel();
            string[]  _groupNameArr = new string[] {} /*{}*/ /*Array.Empty<string>()*/ /*new string[0]*/;

            //determine the keyword
            //keyword can be GroupName, ProductCode, ProductCategory, or Some Text on the Description
            var _gropName_keyword = "and pg.GroupName like '%"+ keyword + "%'";
            var _description_keyword = "or Description Like '%" + keyword + "%'";


            var _query = @"
SELECT TOP 100 pgt.ProductGroupTopId, pgt.Name as StoreName, pgt.OrgID, pgh.GroupHeadID, pgh.HeadName as CategoryHeadName, pg.ProdGroupID, pg.GroupName as CategoryName
FROM ProductGroupTopLink pgtl
join ProductGroupTop pgt on pgtl.ProductGroupTopId = pgt.ProductGroupTopId
join ProductGroupHead pgh on pgtl.GroupHeadID = pgh.GroupHeadID
join ProdGroupLink pgl on pgh.GroupHeadID = pgl.GroupHeadID
join ProductGroups pg on pgl.ProdGroupName = pg.GroupName
where pgt.OrgID = 94 and pgh.GroupHeadID = "+ search_param +" "+ _gropName_keyword +" order by pgt.ProductGroupTopId";
            var _searchCategory = new List<CategoryModel>();
            using (var connection = _dbx.CreateConnection()){
                var _queryResults = connection.Query<CategoryModel>(_query);
                _searchCategory = _queryResults.ToList(); 
                
                //get GroupNames to Array
                var _groupName = new List<string>();
                foreach(var groupName in _searchCategory){
                    if (groupName.CategoryName != null || groupName.CategoryName != ""){
                        _groupName.Add(groupName.CategoryName);
                    }
                }
                _groupNameArr = _groupName.ToArray();
            }  

            //prepare the groupNames string for Sql
            var _groupNameStr = "";
            foreach(var item in _groupNameArr){
                _groupNameStr += "'" + item + "', ";
            }
            if (_groupNameStr == ""){
                _groupNameStr = "-1";
            }else{
                _groupNameStr = _groupNameStr.Remove(_groupNameStr.Length -2, 2);
            }

            var _query2 = @"
Select top 1000 *
from Products
where GroupName in ("+ _groupNameStr +") and OrgID = 94 and Active = 1 and OutputMe = 1";
            var _searchProducts = new List<Product>();
            using (var connection = _dbx.CreateConnection()){
                var _queryResults = connection.Query<Product>(_query2);
                _searchProducts = _queryResults.ToList();             
            }

            var _query3 = @"
Select top 1000 *
from Products
where GroupName in ("+ _groupNameStr +") and OrgID = 94 and Active = 1 and OutputMe = 1 "+ _description_keyword;
            var _searchSpecificProducts = new List<Product>();
            using (var connection = _dbx.CreateConnection()){
                var _queryResults = connection.Query<Product>(_query3);
                _searchSpecificProducts = _queryResults.ToList();             
            }

            //now add the results to the searchModel
            _searchModel = new SearchViewModel(){
                _category = _searchCategory,
                _products = _searchProducts,
                _specificProducts = _searchSpecificProducts
            };
            //return _searchModel; 
            //return new JsonResult(_searchModel);
            /*return new JsonResult()  
            {  
                _categoryModel = _searchCategory,
                _proudctsModel = _searchProducts,
                _specificProdModel = _searchSpecificProducts
            };*/
            return Json( new {
                _category = _searchCategory.ToArray(),
                _products = _searchProducts.ToArray(),
                _specificProducts = _searchSpecificProducts.ToArray(),       
                _keyword = keyword
            });
            //return JSON(json); 
        }
        
        [HttpGet]
        [Route("review/{id}")]
        public IActionResult Review(Int64 id)
        {
            #region Details
            var product = _db.Products.Find(id);
            var featuredPhoto = /*product.ProductImagesx.SingleOrDefault(p => p.Status && p.Featured)*/product.ImgURL;
            var OtherImages = product.ProductImagesx.Where(p => p.ProdID == id).ToList();
            var Features = product.Features.ToList();
            var Specifications = product.Specifications.ToList();
            var reviews = product.ReviewProducts.Where(rs => rs.ReviewStatusID == 2).ToList();
            
            var _branchStock = new List<StockCountModel>();
            _branchStock = GetBranchStock(product.ProdID);

            ViewBag.Product = product;
            ViewBag.FeaturedPhoto = featuredPhoto == null ? "NoPic.jpg" : /*featuredPhoto.Name*/featuredPhoto;
            ViewBag.BranchStock = _branchStock;
            //ViewBag.FeaturedPhotoID = featuredPhoto.ProdImageID;
            ViewBag.OtherPhoto = OtherImages;
            ViewBag.Features = Features;
            ViewBag.Specifications = Specifications;
            ViewBag.ReviewProducts = reviews;


            var relatedProducts = _db.Products.Where(p => p.ManufID == product.ManufID && p.ProdID != product.ProdID && p.Active).ToList();
            //var relatedFeaturedPhoto = relatedProducts.product.SingleOrDefault(p => p.Status && p.Featured);
            ViewBag.RelatedProducts = relatedProducts;
            #endregion

            #region Review
            var reviewProduct = new ReviewProduct()
            {
                ProdID = product.ProdID
            }; 
            #endregion
            return View("Review", reviewProduct);
        }
        [HttpPost]
        [Route("newreview/{id}")]
        public IActionResult NewReview(int id, ReviewProduct reviewProduct)
        {
            var user = User.FindFirst(ClaimTypes.Name);
            var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
            var product = _db.Products.Find(id);

            reviewProduct.CustID = customer.CustID;
            reviewProduct.OrgID = int.Parse(_configuration["appSettings:OrgID"]);//but this i need to change later
            reviewProduct.ProdID = product.ProdID;
            reviewProduct.ProdCode = product.ProductCode;
            reviewProduct.ReviewStatusID = 1;
            reviewProduct.ProdRevDate = DateTime.Now;

            _db.ReviewProducts.Add(reviewProduct);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = reviewProduct.ProdID });
        }

        [HttpGet]
        [Route("reviewresponse/{id}/{flag}/{prodid}")]
        public IActionResult ReviewResponse(int id, Int16 flag, int prodid)
        {
            var user = User.FindFirst(ClaimTypes.Name);
            var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
            var reviewFlag = new ReviewFlags(){
                CustID = customer.CustID,
                ReviewFlagTypeID = flag,
                ReviewFlagDate = DateTime.Now,
                ProdRevID = id
            };
            _db.ReviewFlags.Add(reviewFlag);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = prodid});
        }


        [Route("GetBranchStock")]
        public List<StockCountModel> GetBranchStock(long prodID)
        {
            var query = @"SELECT ob.OrgBraID, ob.OrgBraShort, ob.OrgBraName, bs.StockCount, p.UsualAvailability, sl.ShowStockType 
                        FROM SourceList sl
                        join OrganisationSource os on sl.SourceID = os.SourceID
                        join Products pr on sl.SourceOrgID = pr.OrgID 
                        join BranchStock bs on pr.ProdID = bs.ProdID
                        join OrganisationBranch ob on bs.OrgBraID = ob.OrgBraID
                        join Products p on p.ProductCode = pr.ProductCode and os.OrgSourceID = p.OrgSourceID
                        where (p.ProdID = "+ prodID + @") 
                        order by ob.[Order], ob.OrgBraShort";

            var _branchStock = new List<StockCountModel>();
            using (var connection = _dbx.CreateConnection())
            {
                var branchStock = connection.Query<StockCountModel>(query);
                _branchStock = branchStock.ToList();
            }
            return _branchStock;
        }

        [HttpGet]
        [Route("getbranchesstock")]
        public JsonResult GetBranchesStock(long prodID)
        {
            var query = @"SELECT ob.OrgBraID, ob.OrgBraShort, ob.OrgBraName, bs.StockCount, p.UsualAvailability, sl.ShowStockType 
                        FROM SourceList sl
                        join OrganisationSource os on sl.SourceID = os.SourceID
                        join Products pr on sl.SourceOrgID = pr.OrgID 
                        join BranchStock bs on pr.ProdID = bs.ProdID
                        join OrganisationBranch ob on bs.OrgBraID = ob.OrgBraID
                        join Products p on p.ProductCode = pr.ProductCode and os.OrgSourceID = p.OrgSourceID
                        where (p.ProdID = "+ prodID + @") 
                        order by ob.[Order], ob.OrgBraShort";

            var _branchStock = new List<StockCountModel>();
            using (var connection = _dbx.CreateConnection())
            {
                var branchStock = connection.Query<StockCountModel>(query);
                _branchStock = branchStock.ToList();
            }
            var _branchStockx = JsonConvert.SerializeObject(_branchStock);
            return Json(_branchStockx);
            
        }

        [HttpGet]
        [Route("getdatafeed")]
        public List<DataFeedModel> GetDataFeed()
        {
            var orgID = SharedHelper.GetOrgID();
            var arrOrg = SharedHelper.GetOrgWebDetail();
            var strWEBPriceUsed = arrOrg.WEBPriceUsed.ToString();
            double dblMinStock = double.Parse(SharedHelper.Val(arrOrg.WEBMinStock));
            bool _checkStock = false;
            /*
            bool _outputFile = false;
            bool _fixOutput = false;
            DataTable dtOut = new DataTable();
            DateTime tNow = DateTime.Now;
            */        
            string strKey = "";
            string strID = "";
            string strDC = "";
            string strPrice = "";
            string strShippingProductClass = "";

            if (arrOrg.WEBStockOnly == "D" || arrOrg.WEBStockOnly == "A"){
                _checkStock = true;
            }
            else{
                arrOrg.WEBStockOnly = "A";
            }
            
            try
            {
                if( Request.Query.Count > 0 )
                {
                   try{
                    strKey = Request.Query["key"];
                   }catch{
                   } 
                   try{
                    strID = Request.Query["ID"];
                   }catch{
                   }
                   try{
                    strDC = Request.Query["DC"];
                   }catch{
                   }
                   try{
                    strPrice = Request.Query["Price"];
                   }catch{
                   }
                   try{
                    strShippingProductClass = Request.Query["ShippingProductClass"];
                   }catch{
                   }
                }
            }catch{
                // Code Here...
            }
            
            if (!string.IsNullOrEmpty(strPrice)){
                int iPrice = int.Parse(strPrice);
                if(iPrice > 0 && iPrice < 7){
                    strWEBPriceUsed = strPrice;  
                }
            }
            var _query = "";
            switch (strKey){
                case "1": //Price Check
                _query = string.Format(@"
SELECT Products.ProdID, Products.ProductCode, Products.LongDescription, 
Products.Description, Products.URL, Products.ImgURL, Products.PriceExclVat{0} * 1.15 AS Price, 
Manufacturers.ManufacturerName, Products.GroupName, Organisation.OrgName, 
dbo.GetProductStockCount(Products.ProdID, Products.Status, N'{1}') AS StockCount, 
Products.StockQty FROM Manufacturers RIGHT OUTER JOIN Organisation INNER JOIN
SourceList INNER JOIN OrganisationSource ON SourceList.SourceID = OrganisationSource.SourceID 
ON Organisation.OrgID = SourceList.SourceOrgID RIGHT OUTER JOIN
Products ON OrganisationSource.OrgSourceID = Products.OrgSourceID ON 
Manufacturers.ManufID = Products.ManufID 
WHERE (Products.Active = 1) AND (Products.OutputMe = 1) AND (Products.OrgID = {2})
ORDER BY Products.ProdID", strWEBPriceUsed, arrOrg.WEBStockOnly, orgID);
                break;
                case "2": //bluesting
                break;
                case "3": //Jump shopping
                break;
                case "4": //Traffic synergy
                break;
                case "5": //Hotprice OneShop
                break;
                case "6": //shopmania
                break;
                case "7": //Adwords list
                break;
                case "8": //Bid or Buy
                break;
                case "9": //uPrice.co.za
                break;
                case "10": //Yakealot 
                break;
                case "11": //Facebook Adverts
                _query = string.Format(@"
SELECT Products.ProdID, Products.ProductCode, Products.LongDescription, 
Products.Description, Products.URL, Products.ImgURL, Products.PriceExclVat{0} * 1.15 AS Price, 
Manufacturers.ManufacturerName, Products.GroupName, Organisation.OrgName, 
dbo.GetProductStockCount(Products.ProdID, Products.Status, N'{1}') AS StockCount, 
Products.StockQty FROM Manufacturers RIGHT OUTER JOIN Organisation INNER JOIN
SourceList INNER JOIN OrganisationSource ON SourceList.SourceID = OrganisationSource.SourceID 
ON Organisation.OrgID = SourceList.SourceOrgID RIGHT OUTER JOIN
Products ON OrganisationSource.OrgSourceID = Products.OrgSourceID ON 
Manufacturers.ManufID = Products.ManufID 
WHERE (Products.Active = 1) AND (Products.OutputMe = 1) AND (Products.OrgID = {2})
ORDER BY Products.ProdID", strWEBPriceUsed, arrOrg.WEBStockOnly, orgID);
                break;
                case "12": //New Century (Contains margins)
                _query = string.Format(@"
SELECT Products.ProdID, Products.ProductCode, Products.LongDescription, Products.[Description], 
CAST(Products.Length AS nvarchar(20)) AS LengthCm, CAST(Products.Width AS nvarchar(20)) AS WidthCm, CAST(Products.Height AS nvarchar(20)) AS HeightCm, CAST(Products.Mass AS nvarchar(20)) AS MassKg,
Products.URL, Products.ImgURL, Products.PriceExclVat{0} * 1.15 AS Price, (
SELECT DISTINCT TOP 1 pgh.HeadName
	FROM ProdGroupLink pgl
	INNER JOIN ProductGroupHead pgh ON pgl.GroupHeadID = pgh.GroupHeadID
	WHERE pgh.OrgID = 94 and pgl.ProdGroupName = Products.GroupName
) AS CategoryHead, Products.GroupName, Manufacturers.ManufacturerName, Organisation.OrgName,
dbo.GetProductStockCount(Products.ProdID, Products.[Status], N'{1}') AS StockCount, Products.StockQty FROM Manufacturers 
RIGHT OUTER JOIN Organisation 
INNER JOIN SourceList 
INNER JOIN OrganisationSource ON SourceList.SourceID = OrganisationSource.SourceID ON Organisation.OrgID = SourceList.SourceOrgID 
RIGHT OUTER JOIN Products ON OrganisationSource.OrgSourceID = Products.OrgSourceID ON Manufacturers.ManufID = Products.ManufID 
WHERE (Products.Active = 1) AND (Products.OutputMe = 1) AND (Products.OrgID = {2})
ORDER BY Products.ProdID
",strWEBPriceUsed, arrOrg.WEBStockOnly, orgID);
                break;
                case "13": //Google Merchants Adverts
                _query = string.Format(@"
SELECT Products.ProdID, Products.ProductCode, Products.LongDescription, 
Products.Description, Products.URL, Products.ImgURL, Products.PriceExclVat{0} * 1.15 AS Price, 
Manufacturers.ManufacturerName, Products.GroupName, Organisation.OrgName, 
dbo.GetProductStockCount(Products.ProdID, Products.Status, N'{1}') AS StockCount, 
Products.StockQty FROM Manufacturers RIGHT OUTER JOIN Organisation INNER JOIN
SourceList INNER JOIN OrganisationSource ON SourceList.SourceID = OrganisationSource.SourceID 
ON Organisation.OrgID = SourceList.SourceOrgID RIGHT OUTER JOIN
Products ON OrganisationSource.OrgSourceID = Products.OrgSourceID ON 
Manufacturers.ManufID = Products.ManufID 
WHERE (Products.Active = 1) AND (Products.OutputMe = 1) AND (Products.OrgID = {2})
ORDER BY Products.ProdID", strWEBPriceUsed, arrOrg.WEBStockOnly, orgID);
                break;

            }
            
            var _dataFeed = new List<DataFeedModel>();
            using (var connection = _dbx.CreateConnection())
            {
                var _datafeedProducts = connection.Query<DataFeedModel>(_query);
                _dataFeed = _datafeedProducts.ToList();
            }
            return _dataFeed;
        }

        public enum stockDisplayType
        {
            allBranches = 0,
            DefaultBranch = 1,
            NotDefaultBranches = 2,
            DefaultYesNo = 3
        }
        
    }

    public class SearchViewModel{
        public List<CategoryModel> _category { get; set; }
        public List<Product> _products { get; set; }
        public List<Product> _specificProducts { get; set; }
    }
    public class CategoryModel{
        public long CategoryID { get; set; }
        public long ProductGroupTopID { get; set; } 
        public string /*ProdGroupTopName*/StoreName { get; set; } 
        public long OrgID { get; set; }
        public long GroupHeadID { get; set; }  
        public string /*HeadName*/CategoryHeadName { get; set; }
        public long ProdGroupID { get; set; } 
        public string /*GroupName*/CategoryName { get; set; }  
    } 
    public class ProductsModel{
        public long ProdID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [UIHint("Currency")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PurchasePrice { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, dd MMMM yyyy}")]  
        public DateTime? CreatedDate {get; set;}
    }


}