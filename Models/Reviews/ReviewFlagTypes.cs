using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    [Table("ReviewFlagTypes")]
    public class ReviewFlagTypes
    {
        public ReviewFlagTypes()
        {
            ReviewFlags = new HashSet<ReviewFlags>();
        }

        [Key]
        public Int16 ReviewFlagTypeID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReviewFlags> ReviewFlags { get; set; }

    }
}
