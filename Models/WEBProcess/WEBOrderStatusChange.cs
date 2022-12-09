using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBOrderStatusChange")]
    public class WEBOrderStatusChange 
    {
        [Key]
        public int WebOrderStatusChangeID { get; set; }
        public int OrderID { get; set; }
        public int NewStatusID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Change DateTime")]
        public DateTime? ChangeDateTime { get; set; }
        public int ChangeBy { get; set; }
        
        //[ForeignKey(nameof(ChangeBy))]
        //public Users User { get; set; }
        [ForeignKey(nameof(NewStatusID))]
        public WEBOrderStatus WEBOrderStatus { get; set; }
        [ForeignKey(nameof(OrderID))]
        public WEBOrder WEBOrder { get; set; }


    }
}
