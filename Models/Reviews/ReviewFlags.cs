using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    [Table("ReviewFlags")]
    public class ReviewFlags
    {
        public ReviewFlags()
        {
        }

        [Key]
        public long ReviewFlagID { get; set; }
        public long CustID { get; set; }
        public Int16 ReviewFlagTypeID { get; set; }
        public DateTime ReviewFlagDate { get; set; }
        public long ProdRevID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ReviewProduct ReviewProduct { get; set; }
        public virtual ReviewFlagTypes ReviewFlagType { get; set; }

    }
}
