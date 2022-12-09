using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBOrderStatusAction")]
    public class WEBOrderStatusAction 
    {
        public WEBOrderStatusAction()
        {
            
        }

        [Key]
        public int WEBOrderStatusActionID { get; set; }
        public int OrgID { get; set; }
        public int StatusID { get; set; }
        public string Header { get; set; }
        public string Detail { get; set; }
        public bool? Active { get; set; }

        //Organisation Details
        [ForeignKey(nameof(OrgID))]
        public Organisation Organisation { get; set; }
        [ForeignKey(nameof(StatusID))]
        public WEBOrderStatus WEBOrderStatus { get; set; }

    }
}
