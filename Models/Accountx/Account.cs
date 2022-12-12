using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Accounts")]
    public class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public Int64 AccountID { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public Int64? DefaultBranch { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string AccTel { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Fax no.")]
        public string AccFax { get; set; }

        #region Company Address
        //[Required(ErrorMessage = "Address Line 1. is required")]
        [Display(Name = "Address Line 1")]
        public string Postal1 { get; set; }
        [Display(Name = "Address Line 2(Optional)")]
        public string Postal2 { get; set; }
        [Display(Name = "Address Line 3(Optional)")]
        public string Postal3 { get; set; }
        [Display(Name = "Address Line 4(Optional)")]
        public string Postal4 { get; set; }
        //[Required(ErrorMessage = "Postal Code must be provided")]
        [DataType(DataType.PostalCode), 
         Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        //[Required]
        [Display(Name = "Province")]
        public string Province { get; set; }
        #endregion

        #region Company Address
        //[Required(ErrorMessage = "Address Line 1. is required")]
        [Display(Name = "Address Line 1")]
        public string Delivery1 { get; set; }
        [Display(Name = "Delivery Address Line 2(Optional)")]
        public string Delivery2 { get; set; }
        [Display(Name = "Delivery Address Line 3(Optional)")]
        public string Delivery3 { get; set; }
        [Display(Name = "Delivery Address Line 4(Optional)")]
        public string Delivery4 { get; set; }
        //[Required(ErrorMessage = "Postal Code must be provided")]
        [DataType(DataType.PostalCode), 
         Display(Name = "Postal Code")]
        public string DeliveryCode { get; set; }
        //[Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        #endregion

        public string Notes { get; set; }
        public bool Defalut { get; set; }
        public bool Active { get; set; }
        public Int64? FromDoorID { get; set; }
        public byte UsePrice { get; set; }

        #region bank details
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Bank Account Type")]
        public string BankAccountType { get; set; }
        [Display(Name = "Bank Branch No")]
        public string BankBranchNo { get; set; }
        [Display(Name = "Bank Account No")]
        public string BankAccountNo { get; set; }
        #endregion

        public string VatNo { get; set; }
        [NotMapped, DataType(DataType.Currency)]
        public decimal CreditLimit { get; set; }
        public bool UseSpendingLimit { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime? SpendLimitStartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? SpendLimitEndDate { get; set; }
        
        public Int64? OrgID { get; set; }
        public byte? AccountCreditTypeId { get; set; }
        public Int64? DeliveryID { get; set; }


        [ForeignKey(nameof(AccountCreditTypeId))]
        public virtual AccountCreditType CreditType { get; set; } 
        [ForeignKey(nameof(OrgID))]
        public virtual Organisation Organisation { get; set; }  
        [ForeignKey(nameof(DeliveryID))]
        public virtual WEBDelivery Delivery { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }


    }
}