using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBOrderItems")]
    public class WEBOrderItems
    {
        public WEBOrderItems()
        {
            
        }

        [Key]
        public int ItemID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProdID { get; set; }
        [Required]
        public int ProdQty { get; set; }
        [Required, DataType(DataType.Currency), Display(Name = "Unit Cost")]
        public double Price { get; set; }
        [Required]
        public string ProdDesc { get; set; }
        [Required]
        public string ProdCode { get; set; }
        public int StockCount { get; set; }
        //[DataType(DataType.Currency), Display(Name = "Total")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal LineItemTotal { get; set; }

        [ForeignKey(nameof(OrderID))]
        public WEBOrder WEBOrder { get; set; }
        [ForeignKey(nameof(ProdID))]
        public Product Product { get; set; }

    }
}
