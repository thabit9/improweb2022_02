using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBCustShipping")]
    public class WEBShipping 
    {
        public WEBShipping()
        {
        }

        [Key]
        public long ShippingID { get; set; }
        public long CustID { get; set; }
        public string ShippingDesc { get; set; }
        public string ShippingAddress { get; set; }
        //[Required]
        [DataType(DataType.Text), MaxLength(255),
         Display(Name = "Shipping Code")]
        public string ShippingCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingType { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public long ShippingAddressIEID { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public long MDSColliveryAddressID { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public string CourierDirectKey { get; set; }
        
        [ForeignKey(nameof(CustID))]
        public virtual Customer Customer { get; set; }

    }
}