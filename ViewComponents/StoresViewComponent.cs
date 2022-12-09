using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="Stores")]
    public class StoresViewComponent : ViewComponent
    {
        private readonly improwebContext _db;
        private IConfiguration _configuration { get; set; }

        public StoresViewComponent(improwebContext db, IConfiguration configuration)
        {
            this._db = db;
            this._configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var _orgID =int.Parse(_configuration["appSettings:OrgID"]);
            List<ProductGroupTop> Stores = _db.ProductGroupTops.OrderBy(s => s.Order).Where(s => s.OrgID == _orgID).ToList();
            return View("Index", Stores);
        }
    }
}