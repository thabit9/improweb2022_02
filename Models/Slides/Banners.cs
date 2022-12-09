using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace improweb2022_02.Models
{
    [Table("Banner")]
    public partial class Banners
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

    }
}