using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace improweb2022_02.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            InverseParents = new HashSet<Category>();
            Products = new HashSet<Product>();
        }
        public Int64 Id { get; set; } 
        public string Name { get; set; }  
        public bool Status { get; set; }
        public Int64? ParentId { get; set; }

        public virtual Category parent { get; set;}
        public virtual ICollection<Category> InverseParents { get; set;}
        public virtual ICollection<Product> Products { get; set; }

    }
}