using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    [Table("WEBCustomer")]
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            ReviewProducts = new HashSet<ReviewProduct>();
            ReviewFlags = new HashSet<ReviewFlags>();
            Wishlists = new HashSet<Wishlist>();
            WEBBillings = new HashSet<WEBBilling>();
            WEBShippings = new HashSet<WEBShipping>();
        }

        [Key]
        public Int64 CustID { get; set; }

        [Required]
        public string Title { get; set; }
        [DataType(DataType.Text), MaxLength(80), 
         Display(Name = "First Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Text), MaxLength(80), 
         Display(Name = "Last Name")]
        public string Surname { get; set; }

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string Tel { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string Tel2 { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Fax no.")]
        public string Fax { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), MaxLength(255), Display(Name = "Email Address")]
        public string Email { get; set; }
        public string Company { get; set; }
        public string PostalAdd { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /*[Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }*/

        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        //[Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid phone no.")]
        [Display(Name = "Cell No")]
        public string CellNo { get; set; }

        public string Notes { get; set; }
        //[Required]
        [Display(Name = "Postal Country")]
        public string PostalCountry { get; set; }

        public string PostalType { get; set; }
        public Int64 PostalAddressIEID { get; set; }
        public string IdNo { get; set; }
        public string VatNo { get; set; }
        public byte SendEmails { get; set; }
        
        //Bank Details
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
        [Display(Name = "Account No")]
        public string AccountNo { get; set; }
        [Display(Name = "Branch No")]
        public string BranchNo { get; set; }

        //Commissions and Discounts
        public double CustomerDiscountPercentage { get; set; }
        public byte CustomerDiscountPriceNo { get; set; }
        public double AccountCommissionPercentage { get; set; }
        public string ReferenceCode { get; set; }  
        //[Required]
        public bool IsCommissionActive { get; set; }
        public int TimesToUseCommission { get; set; }
        public double TotalCommissionPercentage { get; set; }    
        //[Required]
        public bool CommissionOnProfit { get; set; }  
        //[Required]
        public bool Active { get; set; }
        public string CDTown { get; set; }


        public Int64 FraudulentUserID { get; set; }
        public Int64 DefaultOrgBranchID { get; set; }
        public int ReferenceMarketingJourneyId { get; set; }  
        public Int64 OrgID { get; set; }
        public Int64 AccountID { get; set; }


        public virtual Organisation Organisation { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; }
        public virtual ICollection<ReviewFlags> ReviewFlags { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual ICollection<WEBBilling> WEBBillings { get; set; }
        public virtual ICollection<WEBShipping> WEBShippings { get; set; }

    }
}
