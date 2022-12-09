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
    [Route("compare")]
    public class CompareController : Controller
    {
        private improwebContext _db = new improwebContext();
        public CompareController(improwebContext db)
        {
            _db = db; 
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            List<CompareItem> compare = SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare");
            ViewBag.Comapare = compare;
            if (SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare") == null)
            {
                ViewBag.countItems = 0;
                //ViewBag.Total = 0;
            }
            else
            {
                ViewBag.countItems = compare.Count;
                //ViewBag.Total = cart.Sum(it => double.Parse(it.PurchasePrice.ToString("#0.00")) * it.Quantity);
            }            
            return View();
        }

        [HttpGet]
        [Route("compare/{id}")]
        public IActionResult Compare(Int64 id, string redirect)
        {
            var product = _db.Products.Find(id);
            /*var photo = product.ProductImagesx.SingleOrDefault(ph => ph.Status && ph.Featured);
            var photoName = photo == null ? "NoPic.jpg" : photo.Name;*/
            if (SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare") == null)
            {
                var compare = new List<CompareItem>();
                compare.Add(new CompareItem {
                    ProdID = product.ProdID, 
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName, 
                    Description = product.Description,
                    PurchasePrice = decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                    Photo =  /*photoName*/product.ImgURL,
                    Quantity = 1,
                    Manufacturer = product.Manufacturer.ManufacturerName,
                    Warranty = GetWarrantyPeriod(product.Description.ToString())/*,
                    ReviewProducts = product.ReviewProducts.Where(rs => rs.ReviewStatusID == 2).ToList()*/
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            }
            else
            {
                var compare = SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare");
                int index = exists(id, compare);
                if (index == -1)
                {
                    compare.Add(new CompareItem {
                        ProdID = product.ProdID, 
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName, 
                        Description = product.Description,
                        PurchasePrice =  decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                        Photo =  /*photoName*/product.ImgURL,
                        Quantity = 1,
                        Manufacturer = product.Manufacturer.ManufacturerName,
                        Warranty = GetWarrantyPeriod(product.Description.ToString())/*,
                        ReviewProducts = product.ReviewProducts.Where(rs => rs.ReviewStatusID == 2).ToList()*/
                    });
                }
                else
                {
                    //int newquantity = cart[index].Quantity++;
                    //cart[index].Quantity = newquantity;
                    compare[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            }
            return Redirect(redirect);
        }

        [HttpPost]
        [Route("compare/{id}")]  
        public IActionResult Compare(int id, int quantity)
        {
            var product = _db.Products.Find(id);
            /*var photo = product.ProductImagesx.SingleOrDefault(ph => ph.Status && ph.Featured);
            var photoName = photo == null ? "NoPic.jpg" : photo.Name;*/
            if (SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare") == null)
            {
                var compare = new List<CompareItem>();
                compare.Add(new CompareItem {
                    ProdID = product.ProdID, 
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName, 
                    Description = product.Description,
                    PurchasePrice =  decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                    Photo =  /*photoName*/product.ImgURL,
                    Quantity = quantity,
                    Warranty = GetWarrantyPeriod(product.Description.ToString())
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            }
            else
            {
                var compare = SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare");
                int index = exists(id, compare);
                if (index == -1)
                {
                    compare.Add(new CompareItem {
                        ProdID = product.ProdID, 
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName, 
                        Description = product.Description,
                        PurchasePrice =  decimal.Parse(product.PurchasePrice.ToString("#0.00")),
                        Photo =  /*photoName*/product.ImgURL,
                        Quantity = quantity,
                        Warranty = GetWarrantyPeriod(product.Description.ToString())
                    });
                }
                else
                {
                    //int newquantity = cart[index].Quantity++;
                    //cart[index].Quantity = newquantity;
                    compare[index].Quantity += quantity;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            }
            return RedirectToAction("Index", "compare");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            var compare = SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare");
            int index = exists(id, compare);
            compare.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            return RedirectToAction("Index", "compare");
        }

        [Route("remove")]
        public IActionResult Remove()
        {
            var compare = SessionHelper.GetObjectFromJson<List<CompareItem>>(HttpContext.Session, "compare");
            compare.Clear();


            SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            return RedirectToAction("Index", "compare");
        }

        public int exists(Int64 id, List<CompareItem> compare)
        {
            for (var i = 0; i < compare.Count; i++)
            {
                if (compare[i].ProdID == id)
                {
                    return 1;
                }
            }
            return -1;
        }

        public string GetWarrantyPeriod(string str){
            string Warranty = "";
            int indexOfComma = -1;
            if(CheckWarrantySpecified(str) == true){
                indexOfComma = GetLastCommaIndex(str);
                //Now get the warranty
                Warranty = str.Substring(indexOfComma + 1);
            }
            return Warranty;
        }
        public int GetLastCommaIndex(string str){
            int index = str.LastIndexOf(',');
            return index;
        }
        public bool CheckWarrantySpecified(string str){
            bool result = false;
            if(str.Contains("Warranty") || str.Contains("warranty")){
                result = true;
            }else{
                result = false;
            }
            return result;
        }
    }
}
