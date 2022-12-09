using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using improweb2022_02.Models;

namespace improweb2022_02.Models
{
    [Table("Users")]
    public class Users
    {
        public Users()
        {
            RoleAccounts = new HashSet<RoleAccount>();
        }

        [Key]
        public Int64 UserID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string JobTitle { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), 
         MaxLength(255), 
         Display(Name = "Email Address")]
        public string EMailAddress { get; set; }//Username
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }//Password
        public string Settings { get; set; }
        public Int64 Menu { get; set; }
        public Int64 SalesRepID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }
        public int PaymentType { get; set; }
        public byte ReminderCount { get; set; }
        public int PaymentStatus { get; set; }
        public Int64 InvoiceTemplateID { get; set; }
        public bool Active { get; set; }
        public bool NoToUpdateEmails { get; set; }
        public bool NoToGrowthMonthly { get; set; }
        public bool NoToStandards { get; set; }
        public bool HasSentIntroMail { get; set; }
        public string Notes { get; set; }
        public byte UserDefaultPrice { get; set; }
        public Int64 Security { get; set; }

        #region bank details
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
        [Display(Name = "Account No")]
        public string AccountNo { get; set; }
        [Display(Name = "Branch No")]
        public string AccountBranch { get; set; }
        #endregion

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string Tel { get; set; }
        [NotMapped, DataType(DataType.Currency)]
        public decimal DefaultRate { get; set; }
        [NotMapped, DataType(DataType.Currency)]
        public decimal DefaultRatePKm { get; set; }
        public bool NoToReviewApprovalEmails { get; set; }
        public bool NoToQuestionEmails { get; set; }
        public bool NoToStockNotUpdatedEmails { get; set; }
        public bool StatementTo { get; set; }
        //public bool Status { get; set; }
        public Int64 OrgID { get; set; }


        [ForeignKey(nameof(OrgID))]
        public virtual Organisation Organisation { get; set; }  
        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }


    }
}