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

namespace improweb2022_02.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private improwebContext _db = new improwebContext();
        private IConfiguration _configuration;
        public ProductController(improwebContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        [Route("details/{id}")]
        public IActionResult Details(Int64 id)
        {
            var product = _db.Products.Find(id);
            var featuredPhoto = /*product.ProductImagesx.SingleOrDefault(p => p.Status && p.Featured)*/product.ImgURL;
            var OtherImages = product.ProductImagesx.Where(p => p.ProdID == id).ToList();
            var Features = product.Features.ToList();
            var Specifications = product.Specifications.ToList();
            var reviews = product.ReviewProducts.Where(rs => rs.ReviewStatusID == 2).ToList();
            //var stockCount = getStockCount(id);

            ViewBag.Product = product;
            //ViewBag.StockCount = stockCount;
            ViewBag.FeaturedPhoto = featuredPhoto == null ? "~/products/NoPic.jpg" : /*featuredPhoto.Name*/featuredPhoto;
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
        public IActionResult Search(string keyword, int search_param, int? page)
        {
            var pageNumber = page ?? 1;

            var category = _db.Categories.Find(search_param);
            ViewBag.Category = category;
            ViewBag.SubCategory = _db.Categories.Where(c => c.ParentId == search_param);
            ViewBag.Manufacturer = _db.Manufacturers.OrderBy(m => m.ManufacturerName)/*.Where(m => m.Status)*/;
            var products = _db.Products.Where(p => p.ProductName.Contains(keyword) && p.CategoryID == search_param && p.Active).ToList();           
            ViewBag.keyword = keyword;
            ViewBag.CountProducts = products.Count(p => p.Active);
            ViewBag.Products = products.ToPagedList(pageNumber, 6);

            return View("Search");
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
            

            ViewBag.Product = product;
            ViewBag.FeaturedPhoto = featuredPhoto == null ? "NoPic.jpg" : /*featuredPhoto.Name*/featuredPhoto;
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


        public int getStockCount(Int64 prodID)
        {
            var query = (from s in _db.SourceLists
                        join os in _db.OrganisationSources on s.SourceID equals os.SourceID
                        join dp in _db.Products on s.SourceOrgID equals dp.OrgID  
                        join bs in _db.BranchStocks on dp.ProdID equals  bs.ProdID
                        join ob in _db.OrganisationBranches on bs.OrgBraID equals ob.OrgBranchID 
                        join p in _db.Products on dp.ProductCode equals p.ProductCode 
                        select s).ToList(); 

            var user = User.FindFirst(ClaimTypes.Name);
            var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
            var product = _db.Products.Find(prodID);
            var StockCount = product.BranchStocks.SingleOrDefault(s => s.ProdID == prodID);

            return StockCount.StockCount;
        }
        public enum stockDisplayType
        {
            allBranches = 0,
            DefaultBranch = 1,
            NotDefaultBranches = 2,
            DefaultYesNo = 3
        }
        
    }
}