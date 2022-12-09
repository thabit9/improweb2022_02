using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Quotations")]
    public class Quotation
    {
        public Quotation()
        {
            
        }

        [Key]
        public int QuotationID { get; set; }
        public long QuotationNo { get; set; }
        public int UserID { get; set; }
        //User Details
        //[ForeignKey(nameof(UserID))]
        //public Users User { get; set; }
        public int AccountID { get; set; }
        public string QuotationFor { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Quotation Date")]
        public DateTime? QuotationDate { get; set; }
        public bool? QuotationUseTax { get; set; }
        public bool? Accepted { get; set; }
        public bool? Ordered { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        public int WEBOrderID { get; set; }
        [ForeignKey(nameof(WEBOrderID))]
        public WEBOrder WEBOrder { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public int DeliveryQuoteID { get; set; }

        //From courier service will need to communicate with the service to get this ID
        [DataType(DataType.Currency)]
        public double DeliveryCost { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public int DeliveryWaybillID { get; set; }
        [DataType(DataType.Currency)]
        public double Discount { get; set; }
        public int CustomerID { get; set; }
        

        [ForeignKey(nameof(CustomerID))]
        public virtual Customer Customer { get; set; }
        public int ShippingID { get; set; }
        [ForeignKey(nameof(ShippingID))]
        public virtual WEBShipping WEBCustShipping { get; set; }
        [ForeignKey(nameof(AccountID))]
        public virtual Account Account { get; set; }
    }
}