using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    public class CompareItem
    {
        //public Product Product { get; set; }
        public Int64 ProdID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [UIHint("Currency")]
        public decimal PurchasePrice { get; set; }
        public string Photo { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Warranty { get; set; }
        /*public List<ReviewProduct> ReviewProducts { get; set; }*/
    }

}