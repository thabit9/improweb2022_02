using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBBank")]
    public class OrganisationBank
    {
        public OrganisationBank()
        { 
        }

        [Key]
        public Int64 BankID { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [DataType(DataType.Text), MaxLength(50), Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(20), Display(Name = "Account No")]
        public string AccountNo { get; set; }
        public Int64 OrgID { get; set; }
        public int BankAccountTypeID { get; set; }
        [DataType(DataType.Text), MaxLength(50), Display(Name = "Account Name")]
        public string AccountName { get; set; }
        public Int64 BankNameID{ get; set; }
        public Int64 OrgBranchID { get; set; }


        [ForeignKey(nameof(OrgID))]
        public virtual Organisation Organisation { get; set; }
        [ForeignKey(nameof(OrgBranchID))]
        public virtual OrganisationBranch OrganisationBranch { get; set; }
        //Bank Details
        [ForeignKey(nameof(BankNameID))]
        public virtual Bank Bank { get; set; }
        [ForeignKey(nameof(BankAccountTypeID))]
        public virtual BankAccountTypex BankAccountType { get; set; }

    }
}
