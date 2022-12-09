using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        [Key]
        public Int64 InvoiceId { get; set; } 
        public DateTime? Date { get; set; }
        public Int64 AccountID { get; set; }
        public Int64 CustID { get; set; }
        public string Description { get; set; }
        public int InvoiceNo { get; set; }
        public Int64 UserID { get; set; }
        public string Reference { get; set; }
        public bool Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }

}