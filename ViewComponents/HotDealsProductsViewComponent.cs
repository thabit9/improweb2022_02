using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="HotDeals")]
    public class HotDealsProductsViewComponent : ViewComponent
    {
        private readonly improwebContext _db;
        private IConfiguration _configuration { get; set; }

        public HotDealsProductsViewComponent(improwebContext db, IConfiguration configuration)
        {
            this._db = db;
            this._configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var _orgID =int.Parse(_configuration["appSettings:OrgID"]);
            List<Product> hotProducts = _db.Products.OrderByDescending(p => p.ProdID).Where(p => p.Active && p.OrgID == _orgID /*&& p.HotDeal*/).Take(2).ToList();
            return View("Index", hotProducts);
        }
    }
}