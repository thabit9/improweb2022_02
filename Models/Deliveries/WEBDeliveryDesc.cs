using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    public class WEBDeliveryDesc
    {
        public WEBDeliveryDesc()
        {         
        }
        
        [Key]
        public int DeliveryDescID { get; set; }
        public string DeliveryDesc { get; set; }

        //This will get a list of deliveries using this desc
        [InverseProperty(nameof(WEBDelivery.DeliveryDesc))]
        public virtual ICollection<WEBDelivery> Deliveries { get; set; }
    }
}