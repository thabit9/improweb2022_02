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
using improweb2022_02.PayGate;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Configuration;
using System.Text;
using improweb2022_02.PayPal;
using Dapper;

namespace improweb2022_02.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private improwebContext _db = new improwebContext();
        private readonly DapperContext _dbx;
        private IConfiguration _configuration { get; set; }
        private IPayment _payment = new Payment();
        public CartController(improwebContext db, DapperContext dbx, IConfiguration configuration)
        {
            _db = db;
            _dbx = dbx;
            _configuration = configuration; 
        }
        
        //readonly static string PayGateID = _configuration["appSettings:PayGateID"];
        //readonly static string PayGateKey  = _configuration["appSettings:PayGateKey"];

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
                    stockCount = 0,//GetStock(product.ProdID),
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
            #region Paypal 
            PayPalConfig payPalConfig = PayPalService.getPayPalConfig();
            ViewBag.payPalConfig = payPalConfig;
            #endregion

            return View("Confirm");
        }

        #region PayGate Transation Methods
        public async Task<ActionResult<JsonResult>> GetRequest()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {         
                var PayGateID = _configuration["appSettings:PayGateID"];
                var PayGateKey  = _configuration["appSettings:PayGateKey"];

                HttpClient http = new HttpClient();
                Dictionary<string, string> request = new Dictionary<string, string>();
                string paymentAmount = (50 * 100).ToString("00"); // amount int cents e.i 50 rands is 5000 cents
                request.Add("PAYGATE_ID", PayGateID);
                request.Add("REFERENCE", "#45846"); // Payment ref e.g ORDER NUMBER
                request.Add("AMOUNT", paymentAmount);
                request.Add("CURRENCY", "ZAR"); // South Africa
                // PayGate Web3 now needs a real/non-localhost url as a RETURN_URL
                // TODO: Here you can add any website url to test, but bear in mind that it will return to this website once payment is completes
                request.Add("RETURN_URL", "https://example.com");
                request.Add("TRANSACTION_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                request.Add("LOCALE", "en-za");
                request.Add("COUNTRY", "ZAF");

                // get authenticated user's email
                // use a valid email, paygate will send a transaction confirmation to it
                /*
                request.Add("EMAIL",
                    HttpContext.User.Identity.IsAuthenticated
                        ? _payment.GetAuthenticatedUser().Email
                        : "<your email address goes here>");
                        */
                request.Add("EMAIL",
                    user.ToString());
                request.Add("CHECKSUM", _payment.GetMd5Hash(request, PayGateKey));

                string requestString = _payment.ToUrlEncodedString(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await http.PostAsync("https://secure.paygate.co.za/payweb3/initiate.trans", content);
                // if the request did not succeed, this line will make the program crash
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();

                Dictionary<string, string> results = _payment.ToDictionary(responseContent);

                if (results.Keys.Contains("ERROR"))
                {
                    return Json(new
                    {
                        success = false,
                        message = "An error occured while initiating your request"
                    }, new Newtonsoft.Json.JsonSerializerSettings());//JsonRequestBehavior.AllowGet);
                }

                if (!_payment.VerifyMd5Hash(results, PayGateKey, results["CHECKSUM"]))
                {
                    return Json(new
                    {
                        success = false,
                        message = "MD5 verification failed"
                    }, new Newtonsoft.Json.JsonSerializerSettings());//JsonRequestBehavior.AllowGet);
                }

                bool IsRecorded = _payment.AddTransaction(request, results["PAY_REQUEST_ID"]);
                if (IsRecorded)
                {
                    return Json(new
                    {
                        success = true,
                        message = "Request completed successfully",
                        results
                    }, new Newtonsoft.Json.JsonSerializerSettings());//JsonRequestBehavior.AllowGet);
                }
                return Json(new
                {
                    success = false,
                    message = "Failed to record a transaction"
                }, new Newtonsoft.Json.JsonSerializerSettings());//JsonRequestBehavior.AllowGet);
            }
        }

        // This is your return url from Paygate
        // This will run when you complete payment
        [HttpPost]
        public async Task<ActionResult> CompletePayment()
        {
            var PayGateID = _configuration["appSettings:PayGateID"];
            var PayGateKey  = _configuration["appSettings:PayGateKey"];

            //string responseContent = Request.Params.ToString();
            string responseContent = Request.QueryString.ToString();
            Dictionary<string, string> results = _payment.ToDictionary(responseContent);

            Transaction transaction = _payment.GetTransaction(results["PAY_REQUEST_ID"]);

            if (transaction == null)
            {
                // Unable to reconsile transaction
                return RedirectToAction("Failed");
            }

            // Reorder attributes for MD5 check
            Dictionary<string, string> validationSet = new Dictionary<string, string>();
            validationSet.Add("PAYGATE_ID", PayGateID);
            validationSet.Add("PAY_REQUEST_ID", results["PAY_REQUEST_ID"]);
            validationSet.Add("TRANSACTION_STATUS", results["TRANSACTION_STATUS"]);
            validationSet.Add("REFERENCE", transaction.REFERENCE);

            if (!_payment.VerifyMd5Hash(validationSet, PayGateKey, results["CHECKSUM"]))
            {
                // checksum error
                return RedirectToAction("Failed");
            }
            /** Payment Status 
             * -2 = Unable to reconsile transaction
             * -1 = Checksum Error
             * 0 = Pending
             * 1 = Approved
             * 2 = Declined
             * 3 = Cancelled
             * 4 = User Cancelled
             */
            int paymentStatus = int.Parse(results["TRANSACTION_STATUS"]);
            if(paymentStatus == 1)
            {
                // Yey, payment approved
                // Do something useful
            }
            // Query paygate transaction details
            // And update user transaction on your database
            await VerifyTransaction(responseContent, transaction.REFERENCE);
            return RedirectToAction("Complete", new { id = results["TRANSACTION_STATUS"] });
        }        
        
        private async Task VerifyTransaction(string responseContent, string Referrence)
        {
            var PayGateID = _configuration["appSettings:PayGateID"];
            var PayGateKey  = _configuration["appSettings:PayGateKey"];

            HttpClient client = new HttpClient();
            Dictionary<string, string> response = _payment.ToDictionary(responseContent);
            Dictionary<string, string> request = new Dictionary<string, string>();

            request.Add("PAYGATE_ID", PayGateID);
            request.Add("PAY_REQUEST_ID", response["PAY_REQUEST_ID"]);
            request.Add("REFERENCE", Referrence);
            request.Add("CHECKSUM", _payment.GetMd5Hash(request, PayGateKey));

            string requestString = _payment.ToUrlEncodedString(request);

            StringContent content = new StringContent(requestString, Encoding.UTF8, "application/x-www-form-urlencoded");

            // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpResponseMessage res = await client.PostAsync("https://secure.paygate.co.za/payweb3/query.trans", content);
            res.EnsureSuccessStatusCode();

            string _responseContent = await res.Content.ReadAsStringAsync();

            Dictionary<string, string> results = _payment.ToDictionary(_responseContent);
            if (!results.Keys.Contains("ERROR"))
            {
                _payment.UpdateTransaction(results, results["PAY_REQUEST_ID"]);
            }

        }

        #endregion

        #region PayPal Transaction Methods
        //code here
        #endregion

        #region Yoco Transaction Methods (Best for card payments)
        //code here
        #endregion

        #region Netcash Transaction Methods
        //code here
        #endregion

        #region PayFast Transaction Methods (Best Overall)
        //code here
        #endregion

        #region Ozow Transaction Methods (Best for EFT Payments)
        //code here
        #endregion


        [Route("complete")]
        public IActionResult Complete(int? id)
        {
            var PayBy = _configuration["appSettings:PayBy"];
            #region Paygate Transaction
            string status = "Unknown";
            if(PayBy == "PayWeb")
            {
                switch (id.ToString())
                {
                    case "-2":
                        status = "Unable to reconsile transaction";
                        break;
                    case "-1":
                        status = "Checksum Error. The values have been altered";
                        break;
                    case "0":
                        status = "Not Done";
                        break;
                    case "1":
                        status = "Approved";
                        break;
                    case "2":
                        status = "Declined";
                        break;
                    case "3":
                        status = "Cancelled";
                        break;
                    case "4":
                        status = "User Cancelled";
                        break;
                    default:
                        status = $"Unknown Status({ id })";
                        break;
                }
                TempData["Status"] = status;
            }
            #endregion
            #region  PayPal Transaction
            else if(PayBy == "PayPal") 
            {
                var result = PDTHolder.Success(Request.Query["tx"].ToString());
                ViewBag.paypalResult = result;
            }
            #endregion
            else{
                //code here...
            }


            return View("Complete");
        }


        public string GetStock(long prodID, string ShowStockType)
        {
            var _query = "";
            try
            {
                string _prodCode = "";
                long _orgID = 0;
                _query = @"
SELECT Products.ProductCode, SourceList.SourceOrgID FROM Products INNER JOIN
OrganisationSource ON Products.OrgSourceID = OrganisationSource.OrgSourceID 
INNER JOIN SourceList ON OrganisationSource.SourceID = SourceList.SourceID
WHERE (Products.ProdID = " + prodID + ")";
                var _productSource = new ProductSource();
                using (var connection = _dbx.CreateConnection())
                {
                    var productSource = connection.Query<ProductSource>(_query).FirstOrDefault();
                    _productSource = productSource;
                    _prodCode = _productSource.ProductCode;
                    _orgID = _productSource.SourceOrgID;
                }

                var strUA = "";
                var strOut = "";
                double dblTCount = 0;
                _query = @"
SELECT OrganisationBranch.OrgBraShort, BranchStock.StockCount,
DistributorProducts.OrgID, DistributorProducts.ProductCode, DistributorProducts.UsualAvailability 
FROM Products DistributorProducts 
INNER JOIN BranchStock ON DistributorProducts.ProdID = BranchStock.ProdID 
INNER JOIN OrganisationBranch ON BranchStock.OrgBraID = OrganisationBranch.OrgBraID
WHERE (DistributorProducts.OrgID = "+ _orgID + @") 
AND (DistributorProducts.ProductCode = N'"+ _prodCode + @"')
ORDER BY OrganisationBranch.OrgBraShort";
                var _stockResults = new List<StockResults>();
                using (var connection = _dbx.CreateConnection())
                {
                    var stockResults = connection.Query<StockResults>(_query);
                    _stockResults = stockResults.ToList();

                    if(_stockResults.Count > 0)
                    {
                        StringBuilder sbOut = new StringBuilder();
                        foreach(var stock in _stockResults)
                        {
                            dblTCount += double.Parse(stock.StockCount.ToString().Trim());
                            double dblSC = double.Parse(stock.StockCount.ToString().Trim());
                            switch(ShowStockType)
                            {

                                case "P":
                                    if (dblSC <= 0)
                                    {
                                        sbOut.Append(stock.OrgBraShort.ToString().Trim() + ":0 ");
                                    }
                                    else
                                    {
                                        sbOut.Append(stock.OrgBraShort.ToString().Trim() + ":" +
                                            stock.StockCount.ToString().Trim() + " ");
                                    }
                                break;
                                case "Y":
                                    if (dblSC <= 0)
                                    {
                                        sbOut.Append(stock.OrgBraShort.ToString().Trim() + ":N ");
                                    }
                                    else
                                    {
                                        sbOut.Append(stock.OrgBraShort.ToString().Trim() + ":Y ");
                                    }
                                break;
                                case "F":
                                    if (dblSC != 0)
                                    {
                                        sbOut.Append(stock.OrgBraShort.ToString().Trim() + ":" +
                                            stock.StockCount.ToString().Trim() + " ");
                                    }
                                break;
                                default:
                                    sbOut.Append(stock.OrgBraShort.ToString().Trim() + ":N/A ");
                                break;
                            }
                            strOut = sbOut.ToString();
                            strUA = stock.UsualAvailability.ToString();
                        }
                        if (dblTCount == 0)
                        {
                            strOut = strUA;
                        }
                    }
                    else
                    {
                        strOut = "Stock quantity not available!";
                    }
                }
                return strOut.Trim();

            }
            catch(Exception)
            {
                //code here..
                 return "Stock quantity not available!";
            }
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
    public class ProductSource{
        public string ProductCode { get; set; }
        public long SourceOrgID { get; set; }
    }
    public class StockResults{
        public string OrgBraShort { get; set; }
        public string UsualAvailability { get; set; }
        public double StockCount { get; set; }
    }
}
