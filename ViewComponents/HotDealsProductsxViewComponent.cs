using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="HotDealsx")]
    public class HotDealsProductsxViewComponent : ViewComponent
    {
        private readonly improwebContext _db;
        private IConfiguration _configuration { get; set; }

        public HotDealsProductsxViewComponent(improwebContext db, IConfiguration configuration)
        {
            this._db = db;
            this._configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var _orgID =int.Parse(_configuration["appSettings:OrgID"]);
            List<Product> hotProductsx = _db.Products.OrderByDescending(p => p.ProdID).Where(p => p.Active && p.OrgID == _orgID/*&& p.HotDeal*/).Skip(2).Take(3).ToList();
            return View("Index", hotProductsx);
        }
    }
}