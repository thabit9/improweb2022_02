using System;
using System.Collections.Generic;
using System.Text;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    //same as shopping cart
    [Table("WEBBasket")]
    public class WEBShoppingCardRecord
    {
        public WEBShoppingCardRecord()
        {  
        }

        [Key]
        public int BasketID { get; set; }
        [Required]
        public int OrgID { get; set; }
        [Required]
        public string SessionID { get; set; }
        [Required]
        public int ProdID { get; set; }
        [Required]
        public int ProdQty { get; set; }
        [Required]
        public string ProdDesc { get; set; }
        [DataType(DataType.Currency), Display(Name = "Unit Price")]
        public decimal Price { get; set; }
        [Required]
        public string ProdCode { get; set; }
        [Required]
        public int CustID { get; set; }
        [Required]
        public int QuotationID { get; set; }

        [DataType(DataType.Currency), Display(Name = "Line Total")]
        public decimal LineItemTotal { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        

        [JsonIgnore]
        [ForeignKey(nameof(OrgID))]
        public virtual Organisation Organisation { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ProdID))]
        public virtual Product Product { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CustID))]
        public virtual Customer Customer { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(QuotationID))]
        public virtual Quotation Quotation { get; set; }
    }
}
