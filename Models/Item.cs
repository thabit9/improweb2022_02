using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    public class Item
    {
        //public Product Product { get; set; }
        public Int64 ProdID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [UIHint("Currency")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PurchasePrice { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, dd MMMM yyyy}")]  
        public DateTime? CreatedDate {get; set;}

        public int? stockCount { get; set; }
        public int Quantity { get; set; }
    }

}