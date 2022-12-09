using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="Bannerx")]
    public class BannerxViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public BannerxViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            List<Bannersx> banners = _db.Bannersx.Where(c => c.Status).ToList();
            return View("Index", banners);
        }
    }
}