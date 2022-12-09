using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("OrganisationSettings")]
    public class OrganisationSetting
    {
        public OrganisationSetting()
        {    
            UpdatePriorities = new HashSet<UpdatePriority>(); 
            //OrgPayMethods = new HashSet<OrgPayMethod>();     
        }

        [Key]
        public Int64 Id { get; set; }    
        public string OrgAbout { get; set; }
        public string OrgNotes { get; set; }
        public string OrgSerialNo { get; set; }
        public string QuotaionHeader { get; set; }
        public string QuotationFooter { get; set; }
        public string InvoiceHeader { get; set; }
        public string invoiceFooter { get; set; }
        public string ReportLogo { get; set; }
        public string WEBOrgURL { get; set; }
        public int WEBPriceUsed { get; set; }
        public string WEBStockOnly { get; set; }
        public int WEBMinStock { get; set; }
        public bool WEBNoImg { get; set; }
        public int WEBUseGroup { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Info Email")]
        public string WEBMailInfo { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Order Email")]
        public string WEBMailOrders { get; set; }
        public bool WEBAutoOrder { get; set; }
        public string WEBProdOrderBy { get; set; }
        public bool DocSigned { get; set; }

        #region Default Dimensions
        [Display(Name = "Default Length")]
        public Single OrgLength { get; set; }
        [Display(Name = "Default Widht")]
        public Single OrgWidth { get; set; }
        [Display(Name = "Default Height")]
        public Single OrgHeight { get; set; }
        [Display(Name = "Default Mass")]
        public Single OrgMass { get; set; }
        #endregion

        public bool WEBHideComponents { get; set; }
        public int CourierCostModel { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Int64 FromDoorID { get; set; }
        public string IExpressUserID { get; set; }
        public double OrgMonthlyPayExtra { get; set; }
        public int OrgPayMethod { get; set; }
        public int OrgShipFrom { get; set; }

        #region bank details
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
        [Display(Name = "Account No")]
        public string AccountNo { get; set; }
        [Display(Name = "Branch No")]
        public string AccountBranch { get; set; }
        #endregion

        public int FinType { get; set; }
        public string WEBReject { get; set; }
        public bool SendNewEmail { get; set; }
        public bool ShowProductImagesInQuotations { get; set; }
        public bool IsLive { get; set; }
        public bool QuotesDirectToInvoice { get; set; }
        public string StatementHeader { get; set; }
        public string StatementFooter { get; set; }
        public int improPayType { get; set; }
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
        public bool DuplicateIntegratedPriority { get; set; }
        public bool UseImproDisti { get; set; }
        public int IntPaymentID { get; set; }
        public string ScreenHtml { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Username")]
        public string MDSUsername { get; set; }
        //[Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string MDSPassword { get; set; }
        public string MDSToken { get; set; }
        public bool EsquireMenu { get; set; }
        public bool MenuAtoZ { get; set; }
        public Single DimMarkup { get; set; }
        public string CDAddressKey { get; set; }
        public string CourierDirectAccount { get; set; }
        public bool Status { get; set; }
        [ForeignKey(nameof(UpdatePriority))]
        public int UpdatePriority { get; set; }
        [ForeignKey(nameof(CourierID))]
        public Int64 CourierID { get; set; }
        [ForeignKey(nameof(Organisation))]
        public Int64 OrgID { get; set; }
       
        public virtual Organisation Organisation { get; set;}
        public virtual ICollection<UpdatePriority> UpdatePriorities { get; set; }
        public virtual ICollection<OrgPayMethod> OrgPayMethods { get; set; }
        //public virtual BankAccountTypex BankAccountType { get; set; }
        public virtual Couriers Courier { get; set; }
    }

    
}