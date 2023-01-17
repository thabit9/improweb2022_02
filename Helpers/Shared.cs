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

namespace improweb2022_02.Helpers
{
    public class Shared
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
			public string Orgstreet5;
			public bool VATRegistered;
			public string FromDoorID;
            public string OrgVATPercentage;
            public FinType FinType;
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


        private improwebContext _db;
        private HttpContextAccessor _httpContextAccessor;
        public Shared()
        {  
            _db = new improwebContext();  
            _httpContextAccessor = new HttpContextAccessor();    
        }

        public WebConfig webConfig = WebConfigService.getWebConfig();
        public string CurrencyFormat()
        {
            return webConfig.CurrencyFormat;
        }
        public string CurrencyFormatNoR()
        {
            return webConfig.CurrencyFormat2;
        }
        public VATData VAT()
        {
            VATData vd = new VATData();
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
        public List<Customer> GetAccUsers(long accountID)
        {
            var customers = _db.Customers.Where(c => c.AccountID == accountID).ToList();
            return customers;
        }
        public string GetAccountNo(long custID)
        {
            var customer = _db.Customers.Where(c => c.CustID == custID).FirstOrDefault();
            var accountID = customer.AccountID;
            var account = _db.Accounts.Where(a => a.AccountID == accountID).FirstOrDefault();
            
            return account.AccountNo;
        }  
        public DataSet GetCartDimensionsByDataSet(long custID)
        {
            DataSet ds = new DataSet();
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
        public List<Dictionary<string, object>> GetCartDimensionsByDictionary(long custID)
        {
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
        public FromDoorAddress GetFromDoorAddress(long branchID)
        {
            FromDoorAddress address = new FromDoorAddress();
            long orgID = long.Parse(webConfig.OrgID.ToString());
            try
            {
                var _orgBranch = _db.OrganisationBranches.Where(o => o.OrgBranchID == branchID).FirstOrDefault();
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
        public Shipping GetShippingGeneral(long custID)
        {
            Shipping _shipping = new Shipping();
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
        public string GetNewPrice(object usePrice)
		{
            if (usePrice == null || int.Parse(usePrice.ToString()) < 1)
                return GetDefaultPrice();
            else
                return usePrice.ToString();
		}
        private string GetDefaultPrice()
		{
			return webConfig.DefaultPrice;
		}
        
        // Sending Emails
        public void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from)
		{
            SendMail(strSubject, strHTMLBody, to, from, null, true);
		}
        public void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from, bool includeSignature)
        {
            SendMail(strSubject, strHTMLBody, to, from, null, includeSignature);
        }
        public void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from, MailAddress[] bcc)
        {
            SendMail(strSubject, strHTMLBody, to, from, bcc, true);
        }
        public void SendMail(string strSubject, string strHTMLBody, MailAddress[] to, MailAddress from, MailAddress[] bcc, bool includeSignature)
		{
            try
            {
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
            catch (Exception ex)
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
        public string GetAdminEMail()
        {
            return webConfig.AdminEmail;
        }
        public string GetOrdersEMail()
        {
            return webConfig.OrderEmail;
        }
        public string GetShippingEmail()
        {
            return webConfig.ShippingEmail;
        }

        private string CreateBrandsMenu()
        {
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
        public string GetStockCount(string strProdID, stockDisplayType sdt)
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
            StringBuilder sbOut = new StringBuilder();
            try
            {
                var _customer = _db.Customers.SingleOrDefault(a => a.Email.Equals(user.Value));

                var _defaultBranch = (from a in _db.Accounts
                              join c in _db.Customers on a.AccountID equals c.AccountID
                              where(c.CustID == _customer.CustID)
                              select new { DefaulBranch = a.DefaultBranch }).FirstOrDefault();
                var _query = (from sl in _db.SourceLists
                              join os in _db.OrganisationSources on sl.SourceID equals os.SourceID
                              join dp in _db.Products 
                              join bs in _db.BranchStocks on dp.ProdID equals bs.ProdID)
            }
            catch
            {
                // Code Here..
            }
            return sbOut.ToString();
        }


        // Seaching a dictionary
        public Dictionary<string, object> SearchList(List<Dictionary<string, object>> testData, 
            Dictionary<string, object> searchPattern)
        {
            return testData.FirstOrDefault(x => searchPattern.All(x.Contains));
        }        
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
        public bool isSouthAfrica(string text)
		{
			return text.ToUpper()=="SOUTH AFRICA";
		}
        
    }
}