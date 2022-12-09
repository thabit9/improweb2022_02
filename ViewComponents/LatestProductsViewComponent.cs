using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="LatestProducts")]
    public class LatestProductsViewComponent : ViewComponent
    {
        private readonly improwebContext _db;
        private IConfiguration _configuration { get; set; }

        public LatestProductsViewComponent(improwebContext db, IConfiguration configuration)
        {
            this._db = db;
            this._configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var _orgID =int.Parse(_configuration["appSettings:OrgID"]);
            List<Product> products = _db.Products.OrderByDescending(p => p.ProdID).Where(p => p.Active && p.OrgID == _orgID).Take(6).ToList();
            return View("Index", products);
        }
    }
}