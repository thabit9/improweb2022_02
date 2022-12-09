using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBDeliveryRule")]
    public class WEBDeliveryRule
    {
        public WEBDeliveryRule()
        {   
            Deliveries = new HashSet<WEBDelivery>();  
        }

        [Key]
        public int WEBDeliveryRuleID { get; set; }
        public string RuleName { get; set; }

        //This will get a list of Deliveries using this rule
        [InverseProperty(nameof(WEBDelivery.DeliveryRule))]
        public virtual ICollection<WEBDelivery> Deliveries { get; set; }
    }
}