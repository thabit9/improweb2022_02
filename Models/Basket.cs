using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBBasket")]
    public class Basket
    {
        public Basket()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        [Key]
        public int BasketId { get; set; } 
        public int OrgID { get; set; }
        public string SessionID { get; set; }
        public int ProdID { get; set; }
        public int ProdQty { get; set; }
        public string ProdDesc { get; set; }
        public decimal Price { get; set; }
        public string ProdCode { get; set; }
        public int CustID { get; set; }
        public int QuotationID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual Product Product { get; set; }
        public virtual Quotation Quotation { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }

}