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
using improweb2022_02.ViewModels;

namespace improweb2022_02.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private improwebContext _db = new improwebContext();
        public CartController(improwebContext db)
        {
            _db = db; 
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                ViewBag.countItems = 0;
                ViewBag.Total = 0;
            }
            else
            {
                ViewBag.countItems = cart.Count;
                ViewBag.Total = cart.Sum(it => double.Parse(it.PurchasePrice.ToString("#0.00")) * it.Quantity);
            }

            
            return View();
        }

        [HttpGet]
        [Route("buy/{id}")]
        public IActionResult Buy(Int64 id)
        {
            var product = _db.Products.Find(id);
            /*var photo = product.ProductImagesx.SingleOrDefault(ph => ph.Status && ph.Featured);
            var photoName = photo == null ? "NoPic.jpg" : photo.Name;*/
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>();
                cart.Add(new Item {
                    ProdID = product.ProdID, 
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName, 
                    Description = product.Description,
                    PurchasePrice = decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                    Photo =  /*photoName*/product.ImgURL,
                    Quantity = 1,
                    CreatedDate = product.CreateDate
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = exists(id, cart);
                if (index == -1)
                {
                    cart.Add(new Item {
                        ProdID = product.ProdID, 
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName, 
                        Description = product.Description,
                        PurchasePrice =  decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                        Photo =  /*photoName*/product.ImgURL,
                        Quantity = 1,
                        CreatedDate = product.CreateDate
                    });
                }
                else
                {
                    //int newquantity = cart[index].Quantity++;
                    //cart[index].Quantity = newquantity;
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        [Route("buy/{id}")]  
        public IActionResult Buy(Int64 id, int quantity)
        {
            var product = _db.Products.Find(id);
            /*var photo = product.ProductImagesx.SingleOrDefault(ph => ph.Status && ph.Featured);
            var photoName = photo == null ? "NoPic.jpg" : photo.Name;*/
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>();
                cart.Add(new Item {
                    ProdID = product.ProdID, 
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName, 
                    Description = product.Description,
                    PurchasePrice =  decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                    Photo = /*photoName*/product.ImgURL,
                    Quantity = quantity,
                    CreatedDate = product.CreateDate
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = exists(id, cart);
                if (index == -1)
                {
                    cart.Add(new Item {
                        ProdID = product.ProdID, 
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName, 
                        Description = product.Description,
                        PurchasePrice =  decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                        Photo =  /*photoName*/product.ImgURL,
                        Quantity = quantity,
                        CreatedDate = product.CreateDate
                    });
                }
                else
                {
                    //int newquantity = cart[index].Quantity++;
                    //cart[index].Quantity = newquantity;
                    cart[index].Quantity += quantity;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        [Route("update")]
        public IActionResult update(int[] quantity)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantity[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index", "cart");
        }


        [Route("remove/{id}")]
        public IActionResult Remove(Int64 id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = exists(id, cart);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index", "Cart");
        }

        [Route("checkout")]
        public IActionResult Checkout()
        {
            
            var user = User.FindFirst(ClaimTypes.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
                //create invoice
                var invoice = new Invoice(){
                    Description = "Invoice Online",
                    Date = DateTime.Now,
                    Reference = "Reference",
                    Status = false,
                    CustID = customer.CustID,

                };
                _db.Invoices.Add(invoice);
                _db.SaveChanges();

                //create invoice details
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                foreach (var item in cart)
                {
                    var invoiceDetails = new InvoiceDetails
                    {
                        InvoiceID = invoice.InvoiceId,
                        ProdID = item.ProdID,
                        Description = item.Description,
                        Amount = decimal.Parse(item.PurchasePrice.ToString("#0.00")),
                        Qty = item.Quantity                   
                    };
                    _db.InvoiceDetails.Add(invoiceDetails);
                    _db.SaveChanges();
                }

                //Remove items in cart
                HttpContext.Session.Remove("cart");
                return RedirectToAction("Thanks");
            }
        }

        [Route("thanks")]
        public IActionResult Thanks()
        {
            return View("Thanks");
        }

        [HttpGet]
        [Route("billingaddress")]
        public IActionResult BillingAddress()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
                ViewBag.customer = customer;
                //get the billing Address
                var billingAddress = _db.WEBBillings.Where(b => b.CustID == customer.CustID).ToList();
                ViewBag.BillingAddress = billingAddress;
                //populate countries
                var countryViewModel = new CountryViewModel();
                countryViewModel.Countries = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Countries.ToList(), "CountryId", "Name"); 
                 
                return View("BillingAddress");   
            }
        }

        [Route("shippingaddress")]
        public IActionResult ShippingAddress()
        {
            return View("ShippingAddress");
        }

        [Route("shipping")]
        public IActionResult Shipping()
        {
            return View("Shipping");
        }

        [Route("payment")]
        public IActionResult Payment()
        {
            return View("Payment");
        }

        [Route("confirm")]
        public IActionResult Confirm()
        {
            return View("Confirm");
        }

        [Route("complete")]
        public IActionResult Complete()
        {
            return View("Complete");
        }

        public int exists(Int64 id, List<Item> cart)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProdID == id)
                {
                    return 1;
                }
            }
            return -1;
        }
    }
}
