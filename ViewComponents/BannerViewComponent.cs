using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="Banner")]
    public class BannerViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public BannerViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            List<Banners> banners = _db.Banners.Where(c => c.Status).ToList();
            return View("Index", banners);
        }
    }
}