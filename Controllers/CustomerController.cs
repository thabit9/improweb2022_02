using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using improweb2022_02.Models;
using improweb2022_02.DataAccess;
using improweb2022_02.ViewModels;
using improweb2022_02.Security;

namespace improweb2022_02.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private improwebContext _db = new improwebContext();
        private SecurityManager securityManager = new SecurityManager();
        public CustomerController(improwebContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            var customerViewModel = new CustomerViewModel();
            customerViewModel.Customer = new Customer();
            customerViewModel.Organisations = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Organisations.ToList(), "Id", "OrgName");
            customerViewModel.Accounts = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Accounts.ToList(), "AccountID", "AccountName");  
            return View("Register", customerViewModel);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(CustomerViewModel customerViewModel)
        {
            var exists = _db.Customers.Count(a => a.Email.Equals(customerViewModel.Customer.Email)) > 0;
            if(!exists){
                //customerViewModel.Customer.Password = BCrypt.Net.BCrypt.HashPassword(customerViewModel.Customer.Password);
                customerViewModel.Customer.Active = true;
                customerViewModel.Customer.DateCreated = DateTime.Now;
                _db.Customers.Add(customerViewModel.Customer);
                _db.SaveChanges();
                var CustID = customerViewModel.Customer.CustID;
            
                //add Role Customer to New Customer
                /*var roleAccount = new RoleAccount()
                {
                    RoleId = 2, //Customer Role on the role table
                    UserId = customerViewModel.Customer.CustID,
                    Status = true
                };
                _db.RoleAccounts.Add(roleAccount);
                _db.SaveChanges();*/

                return RedirectToAction("billingaddress", "Customer", CustID);
            }
            else
            {
                ViewBag.error = "Customer email already exist.";
                return RedirectToAction("register", "Customer", customerViewModel);
            }

        }


        [HttpGet]
        [Route("billingaddress")]
        public IActionResult BillingAddress(int custId)
        {   
            var customerViewModel = new CustomerViewModel();
            customerViewModel.Customer = _db.Customers.Find(custId);   
            customerViewModel.Countries = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Countries.ToList(), "CountryId", "Name");         
            return View("billingaddress", customerViewModel);
        }

        [HttpPost]
        [Route("billingaddress")]
        public IActionResult BillingAddress(CustomerViewModel customerViewModel)
        {
            _db.Entry(customerViewModel.Customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("login", "Customer");
        }


        [HttpGet]
        [Route("login")]
        public IActionResult signin()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult signin(string email, string password)
        {
            var customer = ProcessLogin(email, password);
            if(customer != null)
            {
                securityManager.LogIn(this.HttpContext, customer/*, "Customer_Schema"*/);
                return RedirectToAction("dashboard", "customer");
            }
            else
            {
                ViewBag.error = "Invalid Customer";
                return View("Login");
            }            
        }

        private Customer ProcessLogin(string username, string password)
        {
            var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(username) && a.Active == true);
            if(customer != null)
            {
                if(password == customer.Password)
                {
                    return customer;
                }
                /*var roleOfCustomer = customer.RoleAccounts.FirstOrDefault();
                if(roleOfCustomer.RoleId == 2 && roleOfCustomer.Status == true && BCrypt.Net.BCrypt.Verify(password, customer.Password))
                {
                    return customer;
                }*/
            }
            return null;
        }
    
        [Route("logout")]
        public IActionResult LogOut()
        {
            securityManager.SignOut(this.HttpContext/*, "Customer_Schema"*/);
            return RedirectToAction("login", "customer");
        }
    
        //[Authorize(Roles = "Customer")]
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var customerViewModel = new CustomerViewModel();
            var user = User.FindFirst(ClaimTypes.Name);
            customerViewModel.Customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
            return View("profile", customerViewModel);
        }

        //[Authorize(Roles = "Customer")]
        [HttpPost]
        [Route("profile")]
        public IActionResult Profile(CustomerViewModel customerViewModel)
        {
            var currentCustomer = _db.Customers.Find(customerViewModel.Customer.CustID);
            if(!string.IsNullOrEmpty(customerViewModel.Customer.Password))
            {
                currentCustomer.Password = BCrypt.Net.BCrypt.HashPassword(customerViewModel.Customer.Password);
            }
            #region Fields Changed
            currentCustomer.Title = customerViewModel.Customer.Title;
            currentCustomer.FirstName = customerViewModel.Customer.FirstName;
            currentCustomer.Surname = customerViewModel.Customer.Surname;
            currentCustomer.Tel = customerViewModel.Customer.Tel;
            currentCustomer.Tel2 = customerViewModel.Customer.Tel2;
            currentCustomer.CellNo = customerViewModel.Customer.CellNo;
            currentCustomer.Fax = customerViewModel.Customer.Fax;
            currentCustomer.Email = customerViewModel.Customer.Email;
            currentCustomer.Company = customerViewModel.Customer.Company;
            currentCustomer.PostalCountry = customerViewModel.Customer.PostalCountry;
            currentCustomer.PostalAdd = customerViewModel.Customer.PostalAdd;
            currentCustomer.PostalCode = customerViewModel.Customer.PostalCode;
            #endregion

            _db.SaveChanges();
            return View("profile", currentCustomer);
        }

        //[Authorize(Roles = "Customer")]
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }

        //[Authorize(Roles = "Customer")]
        [HttpGet]
        [Route("changepassword")]
        public IActionResult ChangePassword()
        {
            var customer = new Customer();
            var user = User.FindFirst(ClaimTypes.Name);
            customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
            return View("changepassword", customer);
        }

        //[Authorize(Roles = "Customer")]
        [HttpPost]
        [Route("changepassword")]
        public IActionResult ChangePassword(Customer customer)
        {
            _db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

            return View("changepassword");
        }

        [HttpGet]
        [Route("history")]
        public IActionResult History()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
                ViewBag.invoices = customer.Invoices.OrderByDescending(i => i.InvoiceId).ToList();
                return View("History");
            }
        }

        
        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.invoicesDetails = _db.InvoiceDetails.Where(i => i.InvoiceID == id).ToList();
            return View("Details");
        }

        [HttpGet]
        [Route("wishlist")]
        public IActionResult Wishlist()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                var customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));
                ViewBag.wishlists = _db.Wishlists.OrderByDescending(i => i.WishID).Where(i => i.CustID == customer.CustID).ToList();
            }            
            return View();
        }
    }
}
