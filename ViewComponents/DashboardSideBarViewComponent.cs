using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="DashboardSideBar")]
    public class DashboardSideBarViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public DashboardSideBarViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View("Index");
        }
    }
}