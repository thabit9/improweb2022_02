using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Orders")]
    public class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public Int64 OrderID { get; set; }
        public Int64 OrderNumber { get; set; }
        public Int64 ByLogID { get; set; }
        public Int64 ForSourceID { get; set; }
        public string OrderBranch { get; set; }
        public Int64 OrderBranchID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Sent")]
        public DateTime? DateSent { get; set; }
        public Int16 Status { get; set; }
        public string Notes { get; set; }
        public Int64 WEBOrderID { get; set; }
        public string DeliveryQuoteID { get; set; }
        [DataType(DataType.Currency)]
        public double DeliveryCost { get; set; }
        public string CustRef { get; set; }
        public Int64 QuotationID { get; set; }
        public bool? Paid { get; set; }

        
        //[ForeignKey(nameof(ByLogID))]
        //public Logins Logins { get; set; }    
        //[ForeignKey(nameof(ForSourceID))]
        //public OrganisationSource OrganisationSource { get; set; }
        //public SourceList SourceList { get; set; }
        [ForeignKey(nameof(QuotationID))]
        public virtual Quotation Quotation { get; set; } 
        [ForeignKey(nameof(WEBOrderID))]
        public virtual WEBOrder WEBOrder { get; set; }     
        [ForeignKey(nameof(OrderBranchID))]
        public virtual OrganisationBranch OrganisationBranch { get; set; }  
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }


    }
}
