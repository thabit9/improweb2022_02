using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace improweb2022_02.Models
{
    [Table("Manufacturers")]
    public class Manufacturer  
    {
        public Manufacturer()
        {    
            Products = new HashSet<Product>();  
            //ManufacturersExts = new HashSet<ManufacturersExt>();  
        }

        [Key]
        public Int64 ManufID { get; set; } //ManuFID 
        //[DataType(DataType.Text), MaxLength(50)]
        public string ManufacturerName { get; set; }
        public string Logo { get; set; }
        public string ManufURL { get; set; }
        public int Type { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        //public virtual ICollection<ManufacturersExt> ManufacturersExts { get; set; }
    }
}
