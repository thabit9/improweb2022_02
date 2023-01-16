using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;
using improweb2022_02.DataAccess;
using System.Linq;
using improweb2022_02.Models;

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
        public Shared()
        {  
            _db = new improwebContext();       
        }

        WebConfig webConfig = WebConfigService.getWebConfig();
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
            //var accountNo = _db.Accounts.Join
            return "";
        }       
        public bool isSouthAfrica(string text)
		{
			return text.ToUpper()=="SOUTH AFRICA";
		}

    }
}