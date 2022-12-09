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
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private improwebContext _db = new improwebContext();
        private IConfiguration _configuration { get; set; }
        public ContactController(improwebContext db, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            _logger = logger;
        }


        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            var _orgID =int.Parse(_configuration["appSettings:OrgID"]);
            ViewBag.Organisations = _db.Organisations.SingleOrDefault(o => o.OrgID == _orgID);
            return View();
        }

    }
}
