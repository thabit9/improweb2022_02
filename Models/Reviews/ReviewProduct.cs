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
        public long ProdRevID { get; set; }
        public string ProdCode { get; set; }
        public string ProdRevHeading { get; set; }
        public int ProdRevRating { get; set; }
        public string ProdRevPros { get; set; }
        public string ProdRevCons { get; set; }
        public string ProdRevText { get; set; }
        public DateTime ProdRevDate { get; set; }

        public long ProdID { get; set; }
        public long CustID { get; set; }
        public long OrgID { get; set; }
        public long RefID { get; set; }
        public short ReviewStatusID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual ReviewStatus ReviewStatus { get; set; }
        public virtual ICollection<ReviewFlags> ReviewFlagsx { get; set; }

    }
}
