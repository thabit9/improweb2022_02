using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Helpers;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="CartRight")]
    public class CartRightViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public CartRightViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            if(SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                ViewBag.countItems = 0;
                ViewBag.Total = 0;
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.countItems = cart.Count;
                ViewBag.Total = cart.Sum(it => it.PurchasePrice * it.Quantity);
            }
            
            return View("Index");
        }
    }
}