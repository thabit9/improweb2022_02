using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    [Table("Features")]
    public class Features
    {
        public Features()
        {
        }

        [Key]
        public Int64 FeatureID { get; set; }
        public string Description { get; set; }
        public string FeatureValue { get; set; }
        public int FeatureOrder { get; set; }
        public Int64 ProdID { get; set; }

        [ForeignKey(nameof(ProdID))]
        public virtual Product Product { get; set; }

    }
}
