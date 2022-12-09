using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("ProductImages")]
    public class ProductImages
    {
        [Key]
        public Int64 ProdImgID { get; set; }   
        //public string Name { get; set; }
        public string ImageURL { get; set; }  
        /*public bool Status { get; set; }
        public bool Featured { get; set; }*/  
        public Int64 ProdID { get; set; }

        public virtual Product Productx { get; set; }   
    }
}