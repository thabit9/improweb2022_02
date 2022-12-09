using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Bank")]
    public class Bank
    {       
        public Bank()
        {
        }

        [Key]
        public int Id { get; set; }
        //[Required]
        [DataType(DataType.Text), MaxLength(50), 
         Display(Name = "Bank Name")]
        public string Name { get; set; }
        /*public bool ImproPayAvailable { get; set; }
        public string XMLSteps { get; set; }
        public string HTMLPage { get; set; }*/

    }
}