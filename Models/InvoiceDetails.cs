using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("InvoiceDetail")]
    public class InvoiceDetails
    {
        public InvoiceDetails()
        {
        }

        //public int InvoiceDetailId { get; set; }
        public Int64 InvoiceID { get; set; }
        public Int64 ProdID { get; set; } 
        public string Description { get; set; }
        [UIHint("Currency")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public int Qty { get; set; }
        [UIHint("Currency")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Tax { get; set; }

        /*public decimal Price { get; set; }
        public int Quantity { get; set; }*/

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }

}