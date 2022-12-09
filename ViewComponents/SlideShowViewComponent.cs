using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="SlideShow")]
    public class SlideShowViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public SlideShowViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            List<SlideShow> slideShow = _db.SlideShows.Where(c => c.Status).ToList();
            return View("Index", slideShow);
        }
    }
}