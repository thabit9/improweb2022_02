using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="Brand")]
    public class BrandViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public BrandViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            //List<Manufacturer> brands = _db.Manufacturers.OrderBy(b => b.ManufacturerName)./*Where(c => c.Status).*/ToList();
            var brands = _db.Manufacturers.OrderBy(brands => brands.ManufacturerName).ToList().GroupBy(brands => brands.ManufacturerName.First());
            return View("Index", brands);
        }
    }
}