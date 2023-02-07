using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.Models;
using improweb2022_02.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ecommercestorewithaspcoremvc.ViewComponents
{
    [ViewComponent(Name ="Search")]
    public class SearchViewComponent : ViewComponent
    {
        private readonly improwebContext _db;
        private IConfiguration _configuration { get; set; }

        public SearchViewComponent(improwebContext db, IConfiguration configuration)
        {
            this._db = db;
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
            return View("Index", new InvokeResult() 
            { 
                keyword = keyword, 
                search_param = search_param,
                //categories = categories
                productGroupHeads = productGroupHeads
            });
        }
    }

    public class InvokeResult
    {
        public string keyword { get; set; }
        public long search_param { get; set; }
        //public List<Category> categories { get; set; }
        public List<ProductGroupHead> productGroupHeads { get; set; }
    }
}