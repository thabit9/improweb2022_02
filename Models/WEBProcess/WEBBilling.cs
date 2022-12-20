using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBCustBilling")]
    public class WEBBilling 
    {
        public WEBBilling()
        {
        }

        [Key]
        public long BillingID { get; set; }
        public long CustID { get; set; }
        public string BillingDesc { get; set; }
        public string BillingAddress { get; set; }
        //[Required]
        [DataType(DataType.Text), MaxLength(255),
         Display(Name = "Shipping Code")]
        public string BillingCode { get; set; }
        public string BillingCountry { get; set; }
        public string BillingType { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public long BillingAddressIEID { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public long MDSColliveryAddressID { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public string CourierDirectKey { get; set; }
        
        [ForeignKey(nameof(CustID))]
        public virtual Customer Customer { get; set; }

    }
}