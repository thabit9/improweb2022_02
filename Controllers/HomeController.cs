using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using improweb2022_02.Models;
using improweb2022_02.DataAccess;

namespace improweb2022_02.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private improwebContext _db = new improwebContext();
        public HomeController(improwebContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }


        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.isHome = true;

            #region  Featured Products
            var featuredProducts = _db.Products.OrderByDescending(p => p.ProdID).Where(p => p.Active && p.OutputMe && p.OrgID == 94 && p.Status == 1).Take(100).ToList();
            ViewBag.FeaturedProducts = featuredProducts;
            ViewBag.CountFeaturedProducts = featuredProducts.Count;
            #endregion
            #region Latest Products
            var latestProducts = _db.Products.OrderByDescending(p => p.ProdID).Where(p => p.Active && p.OutputMe && p.OrgID == 94 && p.Status == 1).Take(40).ToList();
            ViewBag.LatestProducts = latestProducts;
            #endregion
            return View();
        }


    }
}
