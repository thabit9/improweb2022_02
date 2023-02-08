using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.Models;
using improweb2022_02.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using improweb2022_02.Helpers;
using Dapper;

namespace ecommercestorewithaspcoremvc.ViewComponents
{
    [ViewComponent(Name ="Search")]
    public class SearchViewComponent : ViewComponent
    {
        private readonly improwebContext _db;
        private readonly DapperContext _dbx;
        private IConfiguration _configuration { get; set; }

        public SearchViewComponent(improwebContext db, DapperContext dbx, IConfiguration configuration)
        {
            this._db = db;
            _dbx = dbx;
            this._configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var _orgID =int.Parse(_configuration["appSettings:OrgID"]);
            string keyword = HttpContext.Request.Query["keyword"].ToString();
            long search_param = -1;
            if(HttpContext.Request.Query.ContainsKey("search_param")){
                search_param = int.Parse(HttpContext.Request.Query["search_param"].ToString());
            }
            //List<Category> categories = _db.Categories.Where(c => c.Status && c.parent == null).ToList();
            List<ProductGroupHead> productGroupHeads = _db.ProductGroupHeads.Where(c => c.OrgID == _orgID).OrderBy(c => c.HeadOrder).ToList();
            //get all the categories
            var categorySearchModel = new List<CategoryModel>();
            categorySearchModel = GetAllCategories(_orgID);

            return View("Index", new InvokeResult() 
            { 
                keyword = keyword, 
                search_param = search_param,
                //categories = categories
                productGroupHeads = productGroupHeads,
                categorySearchModel = categorySearchModel
            });
        }
        public List<CategoryModel> GetAllCategories(long orgID)
        {
            var _query = @"
SELECT TOP 1000 pgt.ProductGroupTopId, pgt.Name as StoreName, pgt.OrgID, pgh.GroupHeadID, pgh.HeadName as CategoryHeadName, pg.ProdGroupID, pg.GroupName as CategoryName
FROM ProductGroupTopLink pgtl
join ProductGroupTop pgt on pgtl.ProductGroupTopId = pgt.ProductGroupTopId
join ProductGroupHead pgh on pgtl.GroupHeadID = pgh.GroupHeadID
join ProdGroupLink pgl on pgh.GroupHeadID = pgl.GroupHeadID
join ProductGroups pg on pgl.ProdGroupName = pg.GroupName
where pgt.OrgID = "+ orgID +@"
order by pgt.ProductGroupTopId";

            var _categories = new List<CategoryModel>();
            using (var connection = _dbx.CreateConnection())
            {
                var categories = connection.Query<CategoryModel>(_query);
                _categories = categories.ToList();
            }
            return _categories;
        }
    }



    public class InvokeResult
    {
        public string keyword { get; set; }
        public long search_param { get; set; }
        //public List<Category> categories { get; set; }
        public List<ProductGroupHead> productGroupHeads { get; set; }
        public List<CategoryModel> categorySearchModel { get; set; }
    }


}