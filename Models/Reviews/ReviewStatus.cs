using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    [Table("ReviewStatus")]
    public class ReviewStatus
    {
        public ReviewStatus()
        {
            ReviewProducts = new HashSet<ReviewProduct>();
        }

        [Key]
        public Int16 ReviewStatusID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; }

    }
}
