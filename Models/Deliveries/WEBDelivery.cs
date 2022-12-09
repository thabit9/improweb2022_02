using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBDelivery")]
    public class WEBDelivery
    {   
        public WEBDelivery()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public Int64 DeliveryID { get; set; }
        [DataType(DataType.Currency)]
        public float Cost { get; set; }
        public string Area { get; set; }
        [DataType(DataType.Currency)]
        public float RuleAmount { get; set; }
        public int MatrixSplit { get; set; }
        public int AfterSplitDivider { get; set; }
        public int MatrixStart { get; set; }
        public bool useVolumetric { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), MaxLength(255), Display(Name = "Username")]
        public string Username { get; set; }
        //[Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Token { get; set; }
        public string CourierDirectAccount { get; set; }
        public int AddressID { get; set; }

        public int WEBDeliveryRuleID { get; set; }
        public int DeliveryDescID { get; set; }
        public Int64 OrgID { get; set; }


        [ForeignKey(nameof(OrgID))]
        public virtual Organisation Organisation { get; set; }
        [ForeignKey(nameof(DeliveryDescID))]
        public virtual WEBDeliveryDesc DeliveryDesc { get; set; }
        [ForeignKey(nameof(WEBDeliveryRuleID))]
        public virtual WEBDeliveryRule DeliveryRule { get; set; }

        [InverseProperty(nameof(Account.Delivery))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}