using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {    
        }
        
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Sign { get; set; }
        public string ISOCode { get; set; }
        public string FractionalUnit { get; set; }
        public int? NumberToBasic { get; set; }
        public string IECountry { get; set; }
        public double? ToOneZAR { get; set; }
        public DateTime? LastZARUpdate { get; set; }
        public string CountryCode { get; set; }
        public string Iso2Code { get; set; }
        public string PhoneCode { get; set; }
    }
}