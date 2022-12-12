using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Organisation")]
    public partial class Organisation
    {
        public Organisation()
        {    
            InverseParents = new HashSet<Organisation>();
            Products = new HashSet<Product>();
            UpdatePriorities = new HashSet<UpdatePriority>();
            OrgPayMethods = new HashSet<OrgPayMethod>();
            UpdatePriorities = new HashSet<UpdatePriority>();
            Accounts = new HashSet<Account>();
            Users = new HashSet<Users>();
            ProductGroupTops = new HashSet<ProductGroupTop>();
            ProductGroupHeads = new HashSet<ProductGroupHead>();
            ReviewProducts = new HashSet<ReviewProduct>();
            OrganisationBranches = new HashSet<OrganisationBranch>();
            OrganisationSources = new HashSet<OrganisationSource>();

        }
        

        [Key]
        public Int64 OrgID { get; set; } 
        //[Required]
        [DataType(DataType.Text), MaxLength(150),
         Display(Name = "Organisation Name")]
        public string OrgName { get; set; }
        //[Required]
        [DataType(DataType.Text), MaxLength(50),
         Display(Name = "Organisation Registration N0")]
        public string OrgRegNo { get; set; }
        [DataType(DataType.Text), MaxLength(50),
         Display(Name = "Organisation VAT N0")]
        public string OrgVATno { get; set; }
        public bool? VATRegistered { get; set; }
        public float? OrgVATPercentage { get; set; }
        public byte? Status { get; set; }
        public byte? BuyLevel { get; set; } //ForeignKey
        public Int64? Industry { get; set; } //IndustryID//ForeignKey
        public string DeliveryCost { get; set; }

        
        #region Company Address
        //[Required(ErrorMessage = "Address Line 1. is required")]
        [Display(Name = "Organisation Address Line 1")]
        public string OrgStreet1 { get; set; }
        [Display(Name = "Organisation Address Line 2(Optional)")]
        public string OrgStreet2 { get; set; }
        [Display(Name = "Organisation Address Line 3(Optional)")]
        public string OrgStreet3 { get; set; }
        [Display(Name = "Organisation Address Line 4(Optional)")]
        public string OrgStreet4 { get; set; }
        //[Required(ErrorMessage = "Organisation Code must be provided")]
        [DataType(DataType.PostalCode), 
         Display(Name = "Organisation Code")]
        public string OrgStreet5 { get; set; } 
        //[Required]
        [Display(Name = "Province")]
        public string OrgProvince { get; set; }
        #endregion
        
        //[Required(ErrorMessage = "Telephone no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string OrgTel1 { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string OrgTel2 { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Fax no.")]
        public string OrgFax { get; set; }
        public string OrgAbout { get; set; }
        public string OrgNotes { get; set; }
        public int? OrgEmployeeCount { get; set; }
        public string OrgSerialNo { get; set; } //another software will generate this
        public string QuotationHeader { get; set; }
        public string QuotationFooter { get; set; }
        public string InvoiceHeader { get; set; }
        public string invoiceFooter { get; set; }
        public string ReportLogo { get; set; }
        public string ccs { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime? CreateDate { get; set; }
        public byte? isFranchise { get; set; }
        public string WEBOrgURL { get; set; }
        public byte? WEBPriceUsed { get; set; }
        public string WEBStockOnly { get; set; }
        public byte? WEBMinStock { get; set; }
        public bool? WEBNoImg { get; set; }
        public byte? WEBUseGroup { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Info Email")]
        public string WEBEMailInfo { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Order Email")]
        public string WEBEMailOrders { get; set; }
        public bool? WEBAutoOrder { get; set; }
        public string WEBProdOrderBy { get; set; }
        public string WEBHomePage { get; set; }
        public string WEBCustom1 { get; set; }
        public string WEBCustom2 { get; set; }
        public bool? DocSigned { get; set; }
        #region Default Dimensions
        [Display(Name = "Default Length")]
        public Single? OrgLength { get; set; }
        [Display(Name = "Default Widht")]
        public Single? OrgWidth { get; set; }
        [Display(Name = "Default Height")]
        public Single? OrgHeight { get; set; }
        [Display(Name = "Default Mass")]
        public Single? OrgMass { get; set; }
        #endregion
        
        public bool? WEBHideComponents { get; set; }
        public byte? CourierCostModel { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Int64? FromDoorID { get; set; }
        public string IExpressUserID { get; set; }
        public double? OrgMonthlyPayExtra { get; set; }
        public byte? OrgPayMethod { get; set; }
        public byte? OrgShipFrom { get; set; }
        #region bank details
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
        [Display(Name = "Account No")]
        public string AccountNo { get; set; }
        [Display(Name = "Branch No")]
        public string AccountBranch { get; set; }
        #endregion
        public string TipsTricksEmailBody { get; set; }
        public int? FinType { get; set; }
        public string WEBReject { get; set; }
        public bool? SendNewsEmail { get; set; }
        public bool? ShowProductImagesInQuotations { get; set; }
        public bool? IsLive { get; set; }
        public bool? QuotesDirectToInvoice { get; set; }
        public string StatementHeader { get; set; }
        public string StatementFooter { get; set; }
        public int? improPayType { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Info Email")]
        public string InvoiceEmail { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Info Email")]
        public string improPAYEmail { get; set; }
        public string DuplicateTwo { get; set; } 
        public string DuplicateMore { get; set; }
        public bool? DuplicateIntegratedPriority { get; set; }
        public bool? UseImproDisti { get; set; }
        public int? IntPaymentID { get; set; }
        public string ScreenHtml { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Username")]
        public string MDSUsername { get; set; }
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string MDSPassword { get; set; }
        public string MDSToken { get; set; }
        public bool? EsquireMenu { get; set; }
        public bool? MenuAtoZ { get; set; }
        public Single? DimMarkup { get; set; }
        public string CDAddressKey { get; set; }
        public string CourierDirectAccount { get; set; }
        //public bool Status { get; set; }
        //[ForeignKey(nameof(UpdatePriority))]
        public int? UpdatePriority { get; set; }

        [ForeignKey(nameof(ParentOrgId))]
        public Int64? ParentOrgId { get; set; }

        
        public virtual Organisation parent { get; set; }        
        public virtual ICollection<Organisation> InverseParents { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        
        //public virtual BankAccountTypex BankAccountType { get; set; }
        //public virtual Industry Industryx { get; set; }
        public virtual Couriers Courier { get; set; }
        public virtual ICollection<UpdatePriority> UpdatePriorities { get; set; }
        public virtual ICollection<OrgPayMethod> OrgPayMethods { get; set; }
        //public virtual ICollection<OrganisationSetting> OrganisationSettings { get;set; }
        public virtual ICollection<Account> Accounts { get;set; } 
        public virtual ICollection<Users> Users { get;set; }
        public virtual ICollection<Customer> Customers{ get; set; }
        public virtual ICollection<ProductGroupTop> ProductGroupTops{ get; set; }
        public virtual ICollection<ProductGroupHead> ProductGroupHeads{ get; set; }
        public virtual ICollection<ReviewProduct> ReviewProducts{ get; set; }
        public virtual ICollection<OrganisationBranch> OrganisationBranches{ get; set; }
        public virtual ICollection<OrganisationSource> OrganisationSources{ get; set; }

    }
}