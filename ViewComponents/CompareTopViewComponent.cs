using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Helpers;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="CompareTop")]
    public class CompareTopViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public CompareTopViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            if(SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare") == null)
            {
                ViewBag.countItems = 0;
                //ViewBag.Total = 0;
            }
            else
            {
                List<CompareItem> compare = SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare");
                ViewBag.countItems = compare.Count;
                //ViewBag.Total = compare.Sum(it => it.PurchasePrice * it.Quantity);
            }
            
            return View("Index");
        }
    }
}