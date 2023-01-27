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
using Dapper;

namespace improweb2022_02.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private improwebContext _db = new improwebContext();
        private readonly DapperContext _dbx;
        public HomeController(improwebContext db, DapperContext dbx, ILogger<HomeController> logger)
        {
            _db = db;
            _dbx = dbx;
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

            var _branchStock = new List<StockCountModel>();
            _branchStock = GetBranchesStock(8748701);
            var _branchStock2 = new List<BranchStock>();
            _branchStock2 = GetBranchesStock();

            try{
             //_branchStockCount = new List<StockCountModel>();
             var  _branchStockCount = (from sl in _db.SourceLists
                    join os in _db.OrganisationSources on sl.SourceID equals os.SourceID
                    join dp in _db.Products on sl.SourceOrgID equals dp.OrgID
                    join bs in _db.BranchStocks on dp.ProdID equals bs.ProdID
                    join ob in _db.OrganisationBranches on bs.OrgBraID equals ob.OrgBraID
                    join p in _db.Products on new { X1=dp.ProductCode, X2=(long)os.OrgSourceID } equals new { X1=p.ProductCode, X2=(long)p.OrgSourceID }
                    where (p.ProdID == 8761839)
                    orderby ob.Order, ob.OrgBraShort
                    select new {
                        OrgBraID = ob.OrgBraID, 
                        OrgBraShort = ob.OrgBraShort, 
                        OrgBraName = ob.OrgBraName, 
                        StockCount = bs.StockCount, 
                        UsualAvailability = p.UsualAvailability, 
                        ShowStockType = sl.ShowStockType
                    }).ToList();
            }
            catch(Exception ex){
                var message = ex;
            }
            try{       
            var _query = _db.SourceLists
                    .Join(_db.OrganisationSources, sl => sl.SourceID, os => os.SourceID, (sl, os) => new { sl, os })
                    .Join(_db.Products, _os => _os.os.OrgSourceID, dp => dp.OrgSourceID, (_os, dp) => new { _os, dp })
                    .Join(_db.BranchStocks, _dp => _dp.dp.ProdID, bs => bs.ProdID, (_dp, bs) => new { _dp, bs })
                    .Join(_db.OrganisationBranches, _bs => _bs.bs.OrgBraID, ob => ob.OrgBraID, (_bs, ob) => new { _bs, ob })
                    .Join(_db.Products, x => new { x1=x._bs._dp.dp.ProductCode, x2=(long)x._bs._dp._os.os.OrgSourceID },
                                        y => new { x1=y.ProductCode, x2=(long)y.OrgSourceID }, (x, y) => new { x, y})                                       
                    .Where(_x => _x.y.ProdID == 8744152)
                    .OrderBy(_x => _x.x.ob.Order)
                    //.ThenByDescending(x => x.x.ob.OrgBraShort).ToList();
                    .ThenBy(x => x.x.ob.OrgBraShort)
                    .Select(a => new {
                        OrgBraID = a.x._bs.bs.OrgBraID,
                        OrgBraShort = a.x.ob.OrgBraShort,
                        OrgBraName = a.x.ob.OrgBraName,
                        StockCount = a.x._bs.bs.StockCount,
                        UsualAvailability = a.y.UsualAvailability,
                        ShowStockType = a.x._bs._dp._os.sl.ShowStockType
                    })
                    .ToList();
            }
            catch(Exception ex){
                var message = ex;
            }
            return View();
        }

        public List<BranchStock> GetBranchesStock()
        {
            var query = "SELECT * FROM BranchStock";
            var _branchStock = new List<BranchStock>();
            using (var connection = _dbx.CreateConnection())
            {
                var branchStock = connection.Query<BranchStock>(query);
                _branchStock = branchStock.ToList();
            }
            return _branchStock;
        }

        [Route("GetBranchesStock")]
        public List<StockCountModel> GetBranchesStock(long prodID)
        {
            var query = @"SELECT ob.OrgBraID, ob.OrgBraShort, ob.OrgBraName, bs.StockCount, p.UsualAvailability, sl.ShowStockType 
                        FROM SourceList sl
                        join OrganisationSource os on sl.SourceID = os.SourceID
                        join Products pr on sl.SourceOrgID = pr.OrgID 
                        join BranchStock bs on pr.ProdID = bs.ProdID
                        join OrganisationBranch ob on bs.OrgBraID = ob.OrgBraID
                        join Products p on p.ProductCode = pr.ProductCode and os.OrgSourceID = p.OrgSourceID
                        where (p.ProdID = "+ prodID + @") 
                        order by ob.[Order], ob.OrgBraShort";

            var _branchStock = new List<StockCountModel>();
            using (var connection = _dbx.CreateConnection())
            {
                var branchStock = connection.Query<StockCountModel>(query);
                _branchStock = branchStock.ToList();
            }
            return _branchStock;
        }

    }
}
