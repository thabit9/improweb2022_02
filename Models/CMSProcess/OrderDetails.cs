using System;
using System.Collections.Generic;
using System.Text;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        public OrderDetails()
        {
        }
        
        [Key]
        public Int64 OrderDetailID { get; set; }
        public Int64 OrderID { get; set; }
        public Int64 ProdID { get; set; }
        public string ProductCode { get; set; }
        public string ProductDesc { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public double PriceExcl { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        public Int64 QuotationDetailID { get; set; }


        [ForeignKey(nameof(QuotationDetailID))]
        public virtual QuotationDetail QuotationDetail { get; set; }
        [ForeignKey(nameof(ProdID))]
        public virtual Product Product { get; set; }
        //Order Details
        [ForeignKey(nameof(OrderID))]
        public virtual Orders Order { get; set; }
    }
}