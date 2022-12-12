using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using improweb2022_02.Models;
using improweb2022_02.DataAccess;
using improweb2022_02.Helpers;
using System.Security.Claims;

namespace improweb2022_02.Controllers
{
    [Route("wishlist")]
    public class WishlistController : Controller
    {
        private improwebContext _db = new improwebContext();
        public WishlistController(improwebContext db)
        {
            _db = db; 
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
                ViewBag.invoices = _db.Wishlists.OrderByDescending(i => i.WishID).Where(i => i.CustID == customer.CustID).ToList();
            }            
            return View();
        }

        [HttpGet]
        [Route("addWishlist/{id}")]
        public IActionResult AddWishlist(Int64 id, string redirect)
        {
            var user = User.FindFirst(ClaimTypes.Name); 
            if(user != null)
            {
                var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
                var product = _db.Products.Find(id);
                //check if product was added by client before
                var wishItemsAdded = _db.Wishlists.Where(w => w.CustID == customer.CustID && w.ProdID == product.ProdID).SingleOrDefault();
                if (wishItemsAdded == null)
                {
                    var WishlistItem = new Wishlist()
                    {
                        CustID = customer.CustID,
                        ProdID = product.ProdID,
                        CreationDate = DateTime.Now,
                        Price = product.PurchasePrice
                    };
                    _db.Add(WishlistItem);
                    _db.SaveChanges();
                }
            }else
            {
                return RedirectToAction("Login", "Customer");
            }
            
            return Redirect(redirect);
        }

    }
}
