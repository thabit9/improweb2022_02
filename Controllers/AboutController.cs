using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using improweb2022_02.Models;
using improweb2022_02.DataAccess;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private improwebContext _db = new improwebContext();
        private IConfiguration _configuration { get; set; }
        public AboutController(improwebContext db, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            _logger = logger;
        }

        
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Organisations = GetOrganisation(getOrgID());
            return View();
        }

        [Route("disclaimer")]
        public IActionResult Disclaimer()
        {
            ViewBag.Organisations = GetOrganisation(getOrgID());
            return View();
        }

        [Route("security")]
        public IActionResult Security()
        {
            ViewBag.Organisations = GetOrganisation(getOrgID());
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            ViewBag.Organisations = GetOrganisation(getOrgID());
            return View();
        }

        [Route("information")]
        public IActionResult Information()
        {
            ViewBag.Organisations = GetOrganisation(getOrgID());
            return View();
        }

        [Route("customer")]
        public IActionResult Customer()
        {
            ViewBag.Organisations = GetOrganisation(getOrgID());
            return View();
        }

        [Route("terms")]
        public IActionResult Terms()
        {
            ViewBag.Organisations = GetOrganisation(getOrgID());
            return View();
        }

        public int getOrgID(){
            return int.Parse(_configuration["appSettings:OrgID"]);
        }
        public Organisation GetOrganisation(int _orgID)
        {
            return _db.Organisations.SingleOrDefault(o => o.OrgID == _orgID);
        }
    }
}
