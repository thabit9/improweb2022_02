using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Helpers;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="Wishlist")]
    public class WishlistViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly improwebContext _db;

        public WishlistViewComponent(improwebContext db, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            var user =_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
            if (user == null)
            {
               ViewBag.countItems = 0;
               //ViewBag.Total = 0; 
            }
            else
            {
                var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
                var wishlist = _db.Wishlists.OrderByDescending(i => i.WishID).Where(i => i.CustID == customer.CustID).ToList();
                ViewBag.countItems = wishlist.Count;
                //ViewBag.Total = 0;
            }
            
            return View("Index");
        }
    }
}