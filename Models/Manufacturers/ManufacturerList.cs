using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using improweb2022_02.Models;

namespace improweb2022_02.Models
{
    [Table("ManufList")]
    public class ManufacturerList
    {
        //public int Id { get; set; }
        public string ManufacturerName { get; set; }
    }
}
