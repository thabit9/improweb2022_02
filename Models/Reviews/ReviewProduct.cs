using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    [Table("ReviewProduct")]
    public class ReviewProduct
    {
        public ReviewProduct()
        {
            ReviewFlagsx = new HashSet<ReviewFlags>(); 
        }

        [Key]
        public Int64 ProdRevID { get; set; }
        public string ProdCode { get; set; }
        public string ProdRevHeading { get; set; }
        public Int16 ProdRevRating { get; set; }
        public string ProdRevPros { get; set; }
        public string ProdRevCons { get; set; }
        public string ProdRevText { get; set; }
        public DateTime ProdRevDate { get; set; }

        public Int64 ProdID { get; set; }
        public Int64 CustID { get; set; }
        public Int64 OrgID { get; set; }
        public Int64 RefID { get; set; }
        public Int16 ReviewStatusID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual ReviewStatus ReviewStatus { get; set; }
        public virtual ICollection<ReviewFlags> ReviewFlagsx { get; set; }

    }
}
