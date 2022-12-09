using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("MapPoint")]
    public class MapPoint 
    {
        public MapPoint()
        {
           MapPoints = new HashSet<MapPoint>(); 
        }
        [Key]
        public Int64 MapPointId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Address { get; set; }

        //[Required(ErrorMessage = "Telephone no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string Tel { get; set; }

        //[Required]
        [DataType(DataType.Text), MaxLength(50),
         Display(Name = "Name")]
        public string Name { get; set; }

        public Int64 AccountID { get; set; }
        [ForeignKey(nameof(AccountID))]
        public virtual Account Account { get; set; }
        //[InverseProperty(nameof(MapPoint.Account))]
        public virtual ICollection<MapPoint> MapPoints { get; set; }
    }
}