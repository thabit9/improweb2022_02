using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.Models;
using improweb2022_02.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace ecommercestorewithaspcoremvc.ViewComponents
{
    [ViewComponent(Name ="Search")]
    public class SearchViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public SearchViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            string keyword = HttpContext.Request.Query["keyword"].ToString();
            int search_param = -1;
            if(HttpContext.Request.Query.ContainsKey("search_param")){
                search_param = int.Parse(HttpContext.Request.Query["search_param"].ToString());
            }
            List<Category> categories = _db.Categories.Where(c => c.Status && c.parent == null).ToList();
            return View("Index", new InvokeResult() 
            { 
                keyword = keyword, 
                search_param = search_param,
                categories = categories
            });
        }
    }

    public class InvokeResult
    {
        public string keyword { get; set; }
        public int search_param { get; set; }
        public List<Category> categories { get; set; }
    }
}