using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net.Mail;
using improweb2022_02.DataAccess;
using System.Linq;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
//using Microsoft.Data.Entity;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace improweb2022_02.Helpers
{
    public class DataFeedModel
    {
        public long ProdID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public int AvailableQty { get; set; }
        public string Condition { get; set; }
        public string Brand { get; set; }
        public string Location { get; set; }
        public string ImageURL { get; set; }
        public string ShippingProductClass { get; set; }
        public string ProductSummary { get; set; }
        public string ProductDescription { get; set; }
        public decimal? LenghtCM { get; set; }
        public decimal? WidthCM { get; set; }
        public decimal? HeightCM { get; set; }
        public decimal? MassKG { get; set; }

    }
    public class CategoryModel{
        public long CategoryID { get; set; }
        public long ProductGroupTopID { get; set; } 
        public string /*ProdGroupTopName*/StoreName { get; set; } 
        public long OrgID { get; set; }
        public long GroupHeadID { get; set; }  
        public string /*HeadName*/CategoryHeadName { get; set; }
        public long ProdGroupID { get; set; } 
        public string /*GroupName*/CategoryName { get; set; }
    }
    [Serializable]
    public class StockCountModel
    {
        public long OrgBraID { get; set; }
        public string OrgBraShort { get; set; }
        public string OrgBraName { get; set; }
        public int? StockCount { get; set; }
        public string UsualAvailability { get; set; }
        public string ShowStockType { get; set; }
    }
    public class SharedHelper
    {
        public struct LoginDetails
		{
			public bool IsLoggedIn;
			public string UserName;
			public string CustID;
			public byte UsePrice;
            public string DefaultBranch;
		}
        public struct OrgWebDetail
		{
			public string OrgName;
			public string WEBEMailInfo;
			public string WEBEMailOrders;
			public string WEBOrgURL;
			public string WEBPriceUsed;
			public string WEBStockOnly;
			public string isFranchise;
			public string WEBMinStock;
			public bool WEBNoImg;
			public string WEBUseGroup;
			public bool WEBAutoOrder;
			public string WEBProdOrderBy;
			public string OrgRegNo;
			public string OrgVATNo;
			public string OrgTel1;
			public string OrgFax;
			public string OrgStreet1;
			public string OrgStreet2;
			public string OrgStreet3;
			public string OrgStreet4;
			public string OrgStreet5;
			public bool VATRegistered;
			public string FromDoorID;
            public string FirstUserID;
            /*public string OrgVATPercentage;
            public FinType FinType;*/
		}
        public enum FinType
        {
            ImproWeb=0,
            Fincon=1,
            FinconBranches=2,
            Manual=3
        }
        public enum BasketResult
        {
            Success,
            Empty,
            InsufficientAmount
        }
        public enum stockDisplayType
        {
            allBranches = 0,
            DefaultBranch = 1,
            NotDefaultBranches = 2,
            DefaultYesNo = 3
        } 
        public struct FromDoorAddress
		{
			public string FromDoorID;
			public string Address;
            public string CollectionID;
            public string CDAddressKey;
            public string Street1;
            public string Street2;
            public string Street3;
            public string Street4;
            public string Street5;
		}
		public struct Shipping
		{
			public string strIEWebID;
			public string strIEGUID;
			public string strSenderName;
			public string strSenderTelCode;
			public string strSenderTelMain; 
			public string strSenderCell;
			public string strSenderEMail;
			public string strReceiverName;
			public string strReceiverTelCode; 
			public string strReceiverTelMain; 
			public string strReceiverCell;
			public string strReceiverEMail;
		}      
    	public struct DeliveryDetails
		{
			public string DeliveryDesc;
			public double Cost;
			public int DeliveryDescID;
		}
        private enum ProductDescriptionHeaderItems
        {
            Overview=1,
            Features=2,
            Specifications=4,
            Reviews=8
        }
        public struct VATData
        {
            public string strVAT;
            public string strOneDotVAT;
            public double VAT;
            public double OneDotVAT;
        }    
        public struct MDSLoginDetail
        {
            public string Username;
            public string Password;
            public string Token;
            public string OrgId;
        }
        public struct basketDims
        {
            public string Dims;
            public double dblMass;
        }        
        
        public const int DEFAULT_PRODUCTS_PER_PAGE = 10;
        public const int MAX_REVIEW_LENGTH = 10000;
        public const int REVIEW_SUMMARY_LENGTH = 100;
        public const int PRODUCT_TITLE_LENGTH = 40;
		public const int PAY_ID_DEPOSIT=1;
		public const int PAY_ID_ELECTRONIC_TRANSFER=2;
        public const int PAY_ID_IMPROPAY=7;
		public const string IE_DESC_ID="5";
        public const string MDS_DESC_ID = "6";
        public const string CD_DESC_ID = "7";
        public const string CD_WAYBILL_PREFIX = "CD100";
		public const string FUNCTION_ERROR = "Error";
		public const string INVALID_LOGIN = "invalid";
        public const string LOGOUT = "logout";
		public const string ACCOUNT_INACTIVE = "inactive";
		public const string DATE_FORMAT="dd/MM/yyyy HH:mm";
		private const string CUSTOM_BOX_KEY="Custom";
		private const int DESC_LENGTH=200;
		//private static string lastWhere="";
        public const string EmailServer = "OIC";
        public const string devSitePath = @"C:\inetpub\wwwroot\esquireonline\";

        public SharedHelper()
        {  
        }

        public static long GetOrgID()
        {
            WebConfig webConfig = WebConfigService.getWebConfig();
			return webConfig.OrgID; 
        }
        public static string GetConnection()
        {
            WebConfig webConfig = WebConfigService.getWebConfig();
			return webConfig.ConnectionString; 
        }
        public static OrgWebDetail GetOrgWebDetail()
        {
            long strOrgID = GetOrgID();
            string _query = @"
SELECT TOP (1) Organisation.OrgName, Organisation.WEBEMailInfo, Organisation.WEBEMailOrders, Organisation.WEBOrgURL, Organisation.WEBPriceUsed, 
    Organisation.WEBStockOnly, Organisation.isFranchise, Organisation.WEBMinStock, Organisation.WEBNoImg, Organisation.WEBUseGroup, 
    Organisation.WEBAutoOrder, Organisation.WEBProdOrderBy, Organisation.OrgRegNo, Organisation.OrgVATNo, Organisation.OrgTel1, Organisation.OrgFax, 
    Organisation.OrgStreet1, Organisation.OrgStreet2, Organisation.OrgStreet3, Organisation.OrgStreet4, Organisation.OrgStreet5, Organisation.VATRegistered, 
    Organisation.FromDoorID, Users.UserID
FROM Organisation INNER JOIN
    Users ON Organisation.OrgID = Users.OrgID
WHERE (Organisation.OrgID = " + strOrgID + ") AND (Users.Menu <> 10);";
            SqlConnection _con = new SqlConnection();
            _con.ConnectionString = GetConnection();
            _con.Open();            
            SqlCommand _cmd = new SqlCommand(_query, _con);
            SqlDataReader _reader = _cmd.ExecuteReader();
            OrgWebDetail _detail = new OrgWebDetail();
            if (!_reader.HasRows)
            {
                return _detail;
            }
            else
            {
                _reader.Read();
                _detail.OrgName = _reader["OrgName"].ToString();
                _detail.WEBEMailInfo = _reader["WEBEMailInfo"].ToString();
                _detail.WEBEMailOrders = _reader["WEBEMailOrders"].ToString();
                _detail.WEBOrgURL = _reader["WEBOrgURL"].ToString();
                _detail.WEBPriceUsed = _reader["WEBPriceUsed"].ToString();
                _detail.WEBStockOnly = _reader["WEBStockOnly"].ToString();
                _detail.isFranchise = _reader["isFranchise"].ToString();
                _detail.WEBMinStock = _reader["WEBMinStock"].ToString();
                _detail.WEBNoImg = (bool)_reader["WEBNoImg"];
                _detail.WEBUseGroup = _reader["WEBUseGroup"].ToString();
                _detail.WEBAutoOrder = (bool)_reader["WEBAutoOrder"];
                _detail.WEBProdOrderBy = _reader["WEBProdOrderBy"].ToString();
                _detail.OrgRegNo = _reader["OrgRegNo"].ToString();
                _detail.OrgVATNo = _reader["OrgVATNo"].ToString();
                _detail.OrgTel1 = _reader["OrgTel1"].ToString();
                _detail.OrgFax = _reader["OrgFax"].ToString();
                _detail.OrgStreet1 = _reader["OrgStreet1"].ToString();
                _detail.OrgStreet2 = _reader["OrgStreet2"].ToString();
                _detail.OrgStreet3 = _reader["OrgStreet3"].ToString();
                _detail.OrgStreet4 = _reader["OrgStreet4"].ToString();
                _detail.OrgStreet5 = _reader["OrgStreet5"].ToString();
                _detail.VATRegistered = _reader["VATRegistered"] == DBNull.Value ? false : (bool)_reader["VATRegistered"];
                _detail.FromDoorID = _reader["FromDoorID"].ToString();
                _detail.FirstUserID = _reader["UserID"].ToString();
                _reader.Close();
                _cmd.Dispose();
                _con.Close();
            }
            return _detail;
        }
        public static string CurrencyFormat()
        {
            WebConfig webConfig = WebConfigService.getWebConfig();
            return webConfig.CurrencyFormat;
        }
        public static string CurrencyFormatNoR()
        {
            WebConfig webConfig = WebConfigService.getWebConfig();
            return webConfig.CurrencyFormat2;
        }
        public static VATData VAT()
        {
            VATData vd = new VATData();
            var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var orgData = _db.Organisations.Where(o => o.OrgID == webConfig.OrgID).FirstOrDefault();
            if (orgData.OrgVATPercentage != null)
            {
                vd.OneDotVAT = 1.14;
                vd.VAT = 0.14;
                vd.strOneDotVAT = "1.14";
                vd.strVAT = "0.14";                
            }
            else
            {
                double dblVat = double.Parse(orgData.OrgVATPercentage.ToString());
                double dblOneDotVat = 1.00 + dblVat;
                vd.VAT = dblVat;
                vd.OneDotVAT = dblOneDotVat;
                vd.strVAT = dblVat.ToString();
                vd.strOneDotVAT = dblOneDotVat.ToString();                
            }
            return vd;
        }
        public static List<Customer> GetAccUsers(long accountID)
        {
            var _db = new improwebContext();
            var customers = _db.Customers.Where(c => c.AccountID == accountID).ToList();
            return customers;
        }
        public static string GetAccountNo(long custID)
        {
            var _db = new improwebContext();
            var customer = _db.Customers.Where(c => c.CustID == custID).FirstOrDefault();
            var accountID = customer.AccountID;
            var account = _db.Accounts.Where(a => a.AccountID == accountID).FirstOrDefault();
            
            return account.AccountNo;
        }  
        public static DataSet GetCartDimensionsByDataSet(long custID)
        {
            DataSet ds = new DataSet();
            var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var _httpContextAccessor = new HttpContextAccessor();
            long orgID = long.Parse(webConfig.OrgID.ToString()); 
            try
            {
                var costModel = 1;
                var DefaultLength = 0;
                var DefaultWidth = 0;
                var DefaultHeight = 0;
                var DefaultMass = 0.0;

                var margins = _db.Organisations.Where(o=>o.OrgID == orgID).FirstOrDefault();
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart");
                /*
                string sqlStr = "SELECT CourierCostModel, OrgLength, OrgWidth, OrgHeight, OrgMass " +
                                "FROM Organisation WHERE (OrgID = " + orgID + ");
                                 SELECT WEBBasket.ProdCode, WEBBasket.ProdQty, " +
                                "Products.Length, Products.Width, Products.Height, Products.Mass " +
                                "FROM WEBBasket INNER JOIN Products ON WEBBasket.ProdID = Products.ProdID " +
                                "WHERE (WEBBasket.CustID = N'" + strCustId + "') AND (WEBBasket.OrgID = " + strOrgID + ") AND (Products.Status <> 4)";
                Note:- Basket has been replaced by Item on the new system
                will at the later stage try to use basket
                */
                costModel = int.Parse(margins.CourierCostModel.ToString());
                DefaultLength = int.Parse(margins.OrgLength.ToString());
                DefaultWidth = int.Parse(margins.OrgWidth.ToString());
                DefaultHeight = int.Parse(margins.OrgHeight.ToString());
                DefaultMass = int.Parse(margins.OrgMass.ToString());

                DataTable dt = new DataTable("ProdDimensions");
                dt.Columns.Add("Length");
				dt.Columns.Add("Width");
				dt.Columns.Add("Height");
				dt.Columns.Add("Mass");
                dt.Columns.Add("ProdCode");
                
                bool blsEmpty = false;
                foreach (var item in cart)
                {      
                    // get the product dimension from the product table 
                    var product = _db.Products.Where(p => p.ProdID == item.ProdID && p.OrgID == orgID && p.Status != 4).FirstOrDefault();

                    float dblQty = float.Parse(Val(item.Quantity.ToString()));
					float dblLength = float.Parse(Val(product.Length.ToString()));
					float dblWidth = float.Parse(Val(product.Length.ToString()));
					float dblHeight = float.Parse(Val(product.Length.ToString()));
					float dblMass = float.Parse(Val(product.Mass.ToString()));
                    string ProdCode = product.ProductCode.ToString();

                    if(dblLength > 0 && dblWidth > 0 && dblHeight > 0 && dblMass > 0 && dblQty > 0)
					{
						/*dblLength *= dblQty;
						dblWidth *= dblQty;
						dblHeight *= dblQty;
						dblMass *= dblQty;*/
					}
					else
					{
                        blsEmpty = true;
                        dblLength = float.Parse(Val(DefaultLength.ToString()));// *dblQty;
                        dblWidth = float.Parse(Val(DefaultWidth.ToString()));// *dblQty;
                        dblHeight = float.Parse(Val(DefaultHeight.ToString()));// *dblQty;
                        dblMass = float.Parse(Val(DefaultMass.ToString()));// *dblQty;
					}
                    int qty = (int)(dblQty + 0.5);
                    for (int i = 0; i < qty; i++)
					    dt.Rows.Add(new object[5] {
                            dblLength.ToString(),
                            dblWidth.ToString(),
						    dblHeight.ToString(),
                            dblMass.ToString(), 
                            ProdCode
                        });
                }

                if(costModel == 1 && blsEmpty)
				{
                    dt.Rows.Clear();
					dt.Rows.Add(new object[6] { DefaultLength, DefaultWidth, DefaultHeight, DefaultMass, "1", "" });
				}
				ds.Tables.Add(dt);
            }
            catch
            {
                // Code here...
            }
            return ds;
        }
        public static List<Dictionary<string, object>> GetCartDimensionsByDictionary(long custID)
        {
            var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var _httpContextAccessor = new HttpContextAccessor();
            List<Dictionary<string, object>> _prodDimensions = new List<Dictionary<string, object>>();
            long orgID = long.Parse(webConfig.OrgID.ToString()); 
            try
            {
                var costModel = 1;
                var DefaultLength = 0.0;
                var DefaultWidth = 0.0;
                var DefaultHeight = 0.0;
                var DefaultMass = 0.0;

                var _default_margins = _db.Organisations.Where(o=>o.OrgID == orgID).FirstOrDefault();
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart");
                /*
                string sqlStr = "SELECT CourierCostModel, OrgLength, OrgWidth, OrgHeight, OrgMass " +
                                "FROM Organisation WHERE (OrgID = " + orgID + ");
                                 SELECT WEBBasket.ProdCode, WEBBasket.ProdQty, " +
                                "Products.Length, Products.Width, Products.Height, Products.Mass " +
                                "FROM WEBBasket INNER JOIN Products ON WEBBasket.ProdID = Products.ProdID " +
                                "WHERE (WEBBasket.CustID = N'" + strCustId + "') AND (WEBBasket.OrgID = " + strOrgID + ") AND (Products.Status <> 4)";
                Note:- Basket has been replaced by Item on the new system
                will at the later stage try to use basket
                */
                costModel = int.Parse(_default_margins.CourierCostModel.ToString());
                DefaultLength = int.Parse(_default_margins.OrgLength.ToString());
                DefaultWidth = int.Parse(_default_margins.OrgWidth.ToString());
                DefaultHeight = int.Parse(_default_margins.OrgHeight.ToString());
                DefaultMass = int.Parse(_default_margins.OrgMass.ToString());
                
                bool blsEmpty = false;
                foreach (var item in cart)
                {      
                    // get the product dimension from the product table 
                    var product = _db.Products.Where(p => p.ProdID == item.ProdID && p.OrgID == orgID && p.Status != 4).FirstOrDefault();

                    float dblQty = float.Parse(Val(item.Quantity.ToString()));
					float dblLength = float.Parse(Val(product.Length.ToString()));
					float dblWidth = float.Parse(Val(product.Length.ToString()));
					float dblHeight = float.Parse(Val(product.Length.ToString()));
					float dblMass = float.Parse(Val(product.Mass.ToString()));
                    string ProdCode = product.ProductCode.ToString();

                    if(dblLength > 0 && dblWidth > 0 && dblHeight > 0 && dblMass > 0 && dblQty > 0)
					{
						/*dblLength *= dblQty;
						dblWidth *= dblQty;
						dblHeight *= dblQty;
						dblMass *= dblQty;*/
					}
					else
					{
                        blsEmpty = true;
                        dblLength = float.Parse(Val(DefaultLength.ToString()));// *dblQty;
                        dblWidth = float.Parse(Val(DefaultWidth.ToString()));// *dblQty;
                        dblHeight = float.Parse(Val(DefaultHeight.ToString()));// *dblQty;
                        dblMass = float.Parse(Val(DefaultMass.ToString()));// *dblQty;
					}
                    int qty = (int)(dblQty + 0.5);
                    for (int i = 0; i < qty; i++)
                    {
                        var dimensions = new Dictionary<string, object>
                        {
                            { "Length", dblLength },
                            { "Width", dblWidth },
                            { "Height", dblHeight },
                            { "Mass", dblMass },
                            { "ProdCode", ProdCode }
                        };
                        _prodDimensions.Add(dimensions);
                    }
                }

                if(costModel == 1 && blsEmpty)
				{
                    var dimensions = new Dictionary<string, object>
                    {
                        { "Length", DefaultLength },
                        { "Width", DefaultWidth },
                        { "Height", DefaultHeight },
                        { "Mass", DefaultMass },
                        { "ProdCode", "1" }
                    };
                    _prodDimensions.Add(dimensions);
				}
				
            }
            catch
            {
                // Code here...
            }
            return _prodDimensions;
        }
        public static FromDoorAddress GetFromDoorAddress(long branchID)
        {
            FromDoorAddress address = new FromDoorAddress();
            var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var _httpContextAccessor = new HttpContextAccessor();
            long orgID = long.Parse(webConfig.OrgID.ToString());
            try
            {
                var _orgBranch = _db.OrganisationBranches.Where(o => o.OrgBraID == branchID).FirstOrDefault();
                if (_orgBranch != null)
                {
                    StringBuilder _stringBuilder = new StringBuilder();
                    #region Address
                    _stringBuilder.Append(_orgBranch.OrgBraStreet1.ToString());
                    _stringBuilder.Append(_orgBranch.OrgBraStreet2.ToString() == "" ? "" : ", " + _orgBranch.OrgBraStreet2.ToString());
                    _stringBuilder.Append(_orgBranch.OrgBraStreet3.ToString() == "" ? "" : ", " + _orgBranch.OrgBraStreet3.ToString());
                    _stringBuilder.Append(_orgBranch.OrgBraStreet4.ToString() == "" ? "" : ", " + _orgBranch.OrgBraStreet4.ToString());
                    _stringBuilder.Append(_orgBranch.OrgBraStreet5.ToString() == "" ? "" : ", " + _orgBranch.OrgBraStreet5.ToString());
                    _stringBuilder.Append(_orgBranch.OrgBraProvince.ToString() == "" ? "" : ", " + _orgBranch.OrgBraProvince.ToString());
                    #endregion

                    address.Address = _stringBuilder.ToString();
                    address.FromDoorID = _orgBranch.FromDoorID.ToString();
                    address.CollectionID = _orgBranch.CollectionID.ToString();
                    address.Street1 = _orgBranch.OrgBraStreet1.ToString();
                    address.Street2 = _orgBranch.OrgBraStreet2.ToString();
                    address.Street3 = _orgBranch.OrgBraStreet3.ToString();
                    address.Street4 = _orgBranch.OrgBraStreet4.ToString();
                    address.Street5 = _orgBranch.OrgBraStreet5.ToString();  
                }
                else
                {
                    throw new Exception("No rows found in table OrganisationBranch");
                }              
            }
            catch
            {
                // Code here...
               	address.FromDoorID = FUNCTION_ERROR;
                address.CollectionID = "0"; 
            }
            return address;
        }
        public static Shipping GetShippingGeneral(long custID)
        {
            Shipping _shipping = new Shipping();
            var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var _httpContextAccessor = new HttpContextAccessor();
            long orgID = long.Parse(webConfig.OrgID.ToString());
            try
            {
                //var _globalKey = _db.GlobalSettings.Where(g => g.GlobalKey == "internetExpressWebID").FirstOrDefault();
                // OR
                var _globalKey = webConfig.internetExpressWebID;
                var _customer = _db.Customers.Where(c => c.CustID == custID).FirstOrDefault();
                var _query = (from o in _db.Organisations
                            join u in _db.Users on o.OrgID equals u.OrgID
                            where(o.OrgID == orgID)
                            orderby u.UserID
                            select new {
                                IExpressUserID = o.IExpressUserID,
                                Title = u.Title,
                                FirstName = u.FirstName,
                                Surname = u.Surname,
                                OrgTel1 = o.OrgTel1,
                                OrgTel2 = o.OrgTel2,
                                EMailAddress = u.EMailAddress
                            }).FirstOrDefault();

                _shipping.strIEWebID = _globalKey;
                if (_query != null){
                    _shipping.strIEGUID = _query.IExpressUserID.ToString();
                    _shipping.strSenderName = _query.Title.ToString().Trim() + " " + 
                                            _query.FirstName.ToString().Trim() + " " + 
                                            _query.Surname.ToString().Trim();
                    string strTelTotal = Val(_query.OrgTel1.ToString());
                    if (strTelTotal.Length > 6)
                    {
                        _shipping.strSenderTelCode = strTelTotal.Substring(0,3);
                        _shipping.strSenderTelMain = strTelTotal.Substring(3);
                    }
                    else
                    {
                        _shipping.strSenderTelCode="";
                        _shipping.strSenderTelMain="";
                    }
                    _shipping.strSenderCell = _query.OrgTel2.ToString();
                    _shipping.strSenderEMail = _query.EMailAddress.ToString();
                }
                if (_customer != null){
                    _shipping.strSenderName = _customer.Title.ToString().Trim() + " " + 
                                            _customer.FirstName.ToString().Trim() + " " + 
                                            _customer.Surname.ToString().Trim();
                    string strTelTotal = Val(_customer.Tel.ToString());
                    if (strTelTotal.Length > 6)
                    {
                        _shipping.strReceiverTelCode = strTelTotal.Substring(0,3);
                        _shipping.strReceiverTelMain = strTelTotal.Substring(3);
                    }
                    else
                    {
                        _shipping.strReceiverTelCode="";
                        _shipping.strReceiverTelMain="";
                    }
                    _shipping.strReceiverCell = _customer.Tel2.ToString();
                    _shipping.strReceiverEMail = _customer.Email.ToString();
                }
            }
            catch
            {
                // Code here...
            }
            return _shipping;
        }
        public static string GetNewPrice(object usePrice)
		{
            if (usePrice == null || int.Parse(usePrice.ToString()) < 1)
                return GetDefaultPrice();
            else
                return usePrice.ToString();
		}
        private static string GetDefaultPrice()
		{
            WebConfig webConfig = WebConfigService.getWebConfig();
			return webConfig.DefaultPrice;
		}
        
        // Sending Emails
        public static void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from)
		{
            SendMail(strSubject, strHTMLBody, to, from, null, true);
		}
        public static void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from, bool includeSignature)
        {
            SendMail(strSubject, strHTMLBody, to, from, null, includeSignature);
        }
        public static void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from, MailAddress[] bcc)
        {
            SendMail(strSubject, strHTMLBody, to, from, bcc, true);
        }
        public static void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from, MailAddress[] bcc, bool includeSignature)
		{
            try
            {
                var _db = new improwebContext();
                WebConfig webConfig = WebConfigService.getWebConfig();
                var _httpContextAccessor = new HttpContextAccessor();

                string[] strAdminEmails = GetAdminEMail().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string strSite = webConfig.SiteName.ToString();
                MailMessage myMail = new MailMessage();
                myMail.Subject = strSubject;
                
            #if DEBUG
                foreach (MailAddress m in to)
                    myMail.To.Add(new MailAddress("henno@automate2.com", m.DisplayName));
            #else
                foreach (MailAddress m in to)
                    myMail.To.Add(m);
                if (from.Address != "productquestions@improweb.com")
                    myMail.CC.Add(from);
                
                foreach (string adminEmail in strAdminEmails)
                    myMail.Bcc.Add(new MailAddress(adminEmail));
                
                if (bcc != null)
                {
                    foreach (MailAddress m in bcc)
                        myMail.Bcc.Add(m);
                }
            #endif


                string strTitle = "";
                if (includeSignature)
                    strTitle = "Sent From " + strSite;

                myMail.From = from;
                myMail.IsBodyHtml = true;             
                myMail.Body = "<html><head><TITLE>" + strTitle + "</TITLE>" +
                    "<STYLE>BODY {FONT-SIZE: 12px; FONT-FAMILY: Arial, helvetica, sans-serif; " +
                    "SCROLLBAR-BASE-COLOR:#2D5281;}</STYLE></head><BODY>" +
                    "<table WIDTH=100% BORDER=0 cellspacing=0 cellpadding=0><tr><td>" + strHTMLBody +
                    "</td></tr><tr><td><HR></td></tr></table></BODY></html>";
                SmtpClient client = new SmtpClient(EmailServer);
                client.Send(myMail);
            }
            catch (Exception)
            {
                string strTo="";
                foreach (MailAddress address in to)
                    strTo += address.Address + ";";
                // Code Here...
                /*DebugMe(1, "Email sending failed. Subject: " + strSubject +
                    "\r\n\r\nFrom: " + from.Address +
                    "\r\n\r\nTo: " + strTo, ex);*/
            }
		}
        // Get Emails
        public static string GetAdminEMail()
        {
            WebConfig webConfig = WebConfigService.getWebConfig();
            return webConfig.AdminEmail;
        }
        public static string GetOrdersEMail()
        {
            WebConfig webConfig = WebConfigService.getWebConfig();
            return webConfig.OrderEmail;
        }
        public static string GetShippingEmail()
        {
            WebConfig webConfig = WebConfigService.getWebConfig();
            return webConfig.ShippingEmail;
        }
        public static MailAddress splitEMailFrom(string strAddress, string strName)
        {
            MailAddress mOut;
            try
            {
                if (strAddress.IndexOf(";") > 2)
                {
                    string[] arrEMail = strAddress.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    mOut = new MailAddress(arrEMail[0], strName);
                }
                else
                {
                    mOut = new MailAddress(strAddress, strName);
                }
            }
            catch (Exception)
            {
                mOut = new MailAddress(strAddress, strName);
                //Code Here...
                //DebugMe(1, "Error splitting E-Mail in splitEMailFrom " + strAddress + " was!", ex);
            }
            return mOut;
        }
        public static MailAddress[] splitEMailTo(string strAddressesToSplit, string strName)
        {
            List<MailAddress> mList = new List<MailAddress>();
            try
            {
                if (strAddressesToSplit.IndexOf(";") > 2)
                {
                    string[] arrEMail = strAddressesToSplit.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string email in arrEMail)
                        mList.Add(new MailAddress(email, strName));
                }
                else
                {
                    mList.Add(new MailAddress(strAddressesToSplit, strName));
                }
            }
            catch (Exception)
            {
                // Code Here...
                //DebugMe(1, "Error splitting E-Mail in splitEMailTo " + strAddressesToSplit + " was!", ex);
            }
            return mList.ToArray();
        }
        public static MailAddress[] GetMailAddresses(string addresses)
        {
            List<MailAddress> toReturn = new List<MailAddress>();
            if (addresses.IndexOf(";") > 0)
            {
                string[] emails = addresses.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string email in emails)
                    toReturn.Add(new MailAddress(email));
            }
            else
            {
                toReturn.Add(new MailAddress(addresses));
            }
            return toReturn.ToArray();
        }

        private static string CreateBrandsMenu()
        {
            var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var _httpContextAccessor = new HttpContextAccessor();

            long orgID = long.Parse(webConfig.OrgID.ToString());
            int iPerRow = int.Parse(webConfig.BrandsPerLine);
            try
            {
                var _query = (from dp in _db.DistProducts
                            join p in _db.Products on dp.DistProdID equals p.ProdID
                            /*left outer */join m in _db.Manufacturers on p.ManufID equals m.ManufID
                            where((p.OutputMe == true) && (p.Active == true) && (m.Logo != "") && (dp.OrgID == orgID))
                            orderby m.ManufacturerName
                            select new {
                                ManufacturerName = m.ManufacturerName,
                                ManufID = p.ManufID,
                                Logo = m.Logo
                            }).ToList();

                StringBuilder sbLines = new StringBuilder();
                double dCount = 0;
                foreach (var brand in _query)
                {
                    // brands html line
                    StringBuilder sbLine = new StringBuilder(webConfig.BrandsLine.ToString());
                    int idiv = System.Convert.ToInt32(dCount / iPerRow);
                    if (dCount / iPerRow == idiv && dCount > 0)
                        sbLines.Append(webConfig.BrandLineSplit.ToString());

                    sbLine.Replace("{linkURL}", string.Format(@"FindBrand.aspx?ID={0}&Brand={1}&Logo={2}",
                            brand.ManufID.ToString(), 
                            System.Web.HttpUtility.UrlEncode(brand.ManufacturerName.ToString()),
                            System.Web.HttpUtility.UrlEncode(brand.Logo.ToString())));
                    sbLine.Replace("{imgURL}", brand.Logo.ToString());
                    sbLines.Append(sbLine.ToString());
                    dCount++;
                }
            }
            catch
            {
                // Code Here...
            }
            return "";
        }
        
        public static long? GetDefaultBranch()
        {
            var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var _httpContextAccessor = new HttpContextAccessor();

            var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
            if(user != null){
                var _customer = _db.Customers.Where(a => a.Email.Equals(user.Value) && a.OrgID == 94).SingleOrDefault();
                var _defaultBranch = (from a in _db.Accounts
                    join c in _db.Customers on a.AccountID equals c.AccountID
                    where(c.CustID == _customer.CustID)
                    select new { DefaulBranch = a.DefaultBranch }).FirstOrDefault();
                return _defaultBranch.DefaulBranch;
            }
            else
            {
                return 0;
            }
            
        }
        public static List<StockCountModel> GetStockCount(long prodID/*, stockDisplayType sdt*/)
        {         
            //var _db = new improwebContext();
            WebConfig webConfig = WebConfigService.getWebConfig();
            var _httpContextAccessor = new HttpContextAccessor();

            var _branchStockCount = new List<StockCountModel>();
            //var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name); 
            //StringBuilder sbOut = new StringBuilder();
            //try
            //{
                /*
                SELECT Accounts.DefaultBranch 
                FROM Accounts INNER JOIN WEBCustomer ON Accounts.AccountID = WEBCustomer.AccountID 
                WHERE (WEBCustomer.CustID = 54600") => DefaultBranch = 1

                SELECT OrganisationBranch.OrgBraID, OrganisationBranch.OrgBraShort, OrganisationBranch.OrgBraName, BranchStock.StockCount, Products.UsualAvailability, SourceList.ShowStockType 
                FROM SourceList 
                    INNER JOIN OrganisationSource ON SourceList.SourceID = OrganisationSource.SourceID 
                    INNER JOIN Products DistributorProducts 
                    INNER JOIN BranchStock ON DistributorProducts.ProdID = BranchStock.ProdID 
                    INNER JOIN OrganisationBranch ON BranchStock.OrgBraID = OrganisationBranch.OrgBraID 
                    INNER JOIN Products ON DistributorProducts.ProductCode = Products.ProductCode 
                    ON SourceList.SourceOrgID = DistributorProducts.OrgID AND OrganisationSource.OrgSourceID = Products.OrgSourceID 
                WHERE (Products.ProdID = 8744152) ORDER BY OrganisationBranch.[Order], OrganisationBranch.OrgBraShort
                */ 
                /*  
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
                    .ThenBy(x => x.x.ob.OrgBraShort).ToList();
                */
                /*
                var _customer = _db.Customers.Where(a => a.Email.Equals(user.Value) && a.OrgID == 94).SingleOrDefault();
                var _defaultBranch = (from a in _db.Accounts
                    join c in _db.Customers on a.AccountID equals c.AccountID
                    where(c.CustID == _customer.CustID)
                    select new { DefaulBranch = a.DefaultBranch }).FirstOrDefault();
                */
                using (var _db = new improwebContext()){
                var _TestDataRequest = _db.OrganisationBranches.ToList();
                _branchStockCount = (from sl in _db.SourceLists
                    join os in _db.OrganisationSources on sl.SourceID equals os.SourceID
                    join dp in _db.Products on sl.SourceOrgID equals dp.OrgID
                    join bs in _db.BranchStocks on dp.ProdID equals bs.ProdID
                    join ob in _db.OrganisationBranches on bs.OrgBraID equals ob.OrgBraID
                    join p in _db.Products on new { X1=dp.ProductCode, X2=(long)os.OrgSourceID } equals new { X1=p.ProductCode, X2=(long)p.OrgSourceID }
                    where (p.ProdID == prodID)
                    orderby ob.Order, ob.OrgBraShort
                    select new StockCountModel {
                        OrgBraID = ob.OrgBraID, 
                        OrgBraShort = ob.OrgBraShort, 
                        OrgBraName = ob.OrgBraName, 
                        StockCount = bs.StockCount, 
                        UsualAvailability = p.UsualAvailability, 
                        ShowStockType = sl.ShowStockType
                    }).ToList();
                }

            /*}
            catch
            {
                // Code Here..
            }*/
            return _branchStockCount;
        }
        public static double GetProductStockCount(long prodID, long branchID)
        {     
            var _db = new improwebContext();
            int toReturn = 0;
            var _stockCount = (from sl in _db.SourceLists
                join os in _db.OrganisationSources on sl.SourceID equals os.SourceID
                join dp in _db.Products on sl.SourceOrgID equals dp.OrgID
                join bs in _db.BranchStocks on dp.ProdID equals bs.ProdID
                join ob in _db.OrganisationBranches on bs.OrgBraID equals ob.OrgBraID
                join p in _db.Products on new { X1=dp.ProductCode, X2=(long)os.OrgSourceID } equals new { X1=p.ProductCode, X2=(long)p.OrgSourceID }
                where (p.ProdID == prodID && ob.OrgBraID == branchID)
                orderby ob.Order, ob.OrgBraShort
                select new {
                    StockCount = bs.StockCount
                }).FirstOrDefault();

            if(_stockCount != null)
                toReturn = (int)Math.Round((double)_stockCount.StockCount);
        
            return toReturn;
        }        
        
        public static Customer GetCustomerDetails(long custID)
        {     
            var _db = new improwebContext();
            var _customer =_db.Customers.Where(c => c.CustID == custID).FirstOrDefault();
            return _customer;
        }
        public static List<Country> GetCountries() 
        {     
            var _db = new improwebContext();
            var _countries = _db.Countries.OrderBy(c => c.Name).ToList();
            return _countries;
        }

        // Seaching a dictionary
        /*
        public static Dictionary<string, object> SearchList(List<Dictionary<string, object>> testData, 
            Dictionary<string, object> searchPattern)
        {
            return testData.FirstOrDefault(x => searchPattern.All(x.Contains));
        }  
        public static List<Dictionary<string, object>> SearchList2(this List<Dictionary<string, object>> list,
            Dictionary<string, object> searchPattern)
        {
            return list.Where(item =>
                searchPattern.All(x => item.ContainsKey(x.Key) && 
                    x.Value.Equals(item[x.Key])
                )).ToList();
        } 
        public static List<Dictionary<string, object>> SearchList3(List<Dictionary<string, object>> testData, 
            Dictionary<string, object> searchPattern)
        {
            return testData.Where(t =>
                {
                    bool flag = true;
                    foreach (KeyValuePair<string, object> p in searchPattern)
                    {
                        if (!t.ContainsKey(p.Key) || !t[p.Key].Equals(p.Value))
                        {
                            flag = false;
                            break;
                        }
                    }
                    return flag;
                }).ToList();

        }  
        public static List<Dictionary<string, object>> SearchList4(List<Dictionary<string, object>> testData, 
            Dictionary<string, object> searchPattern)
        {
            return testData.Where(t => searchPattern
                    .All(p => t.ContainsKey(p.Key) && t[p.Key].Equals(p.Value))).ToList();
        } 
        */  
		public static string Val(string strIn)
		{
			strIn = strIn==null?"":strIn;
			char[] chrsIn = strIn.ToCharArray();
			string strOut="";
			foreach (char charIn in chrsIn)
			{
				if(Char.IsNumber(charIn) || charIn.ToString()=="." ||charIn.ToString()=="-")
				{
					strOut+=charIn.ToString();
				}
			}
			if(strOut=="")
			{
				strOut="0";
			}
			return strOut;
		}
        public static bool isSouthAfrica(string text)
		{
			return text.ToUpper()=="SOUTH AFRICA";
		}
        
    }
}