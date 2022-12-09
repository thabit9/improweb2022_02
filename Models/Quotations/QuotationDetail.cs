using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("QuotationDetail")]
    public class QuotationDetail
    {
        public QuotationDetail()
        {
            
        }

        [Key]
        public int QuotationDetailID { get; set; }
        public int QuotationID { get; set; }
        public int ProdID { get; set; }
        public string ProductCode { get; set; }
        public string ProductDesc { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public double PurchasePriceExcl { get; set; }
        [DataType(DataType.Currency)]
        public double PriceExcl { get; set; }
        public bool? Optional { get; set; }
        public bool? Accepted { get; set; }
        public int Ordered { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        

        [ForeignKey(nameof(QuotationID))]
        public Quotation Quotation { get; set; }
        [ForeignKey(nameof(ProdID))]
        public Product Product { get; set; }

    }
}
