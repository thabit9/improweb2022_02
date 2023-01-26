using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("OrganisationBranch")]
    public class OrganisationBranch
    {
        public OrganisationBranch()
        {
            BranchStocks = new HashSet<BranchStock>();
        }

        [Key]
        public Int64 OrgBraID { get; set; }
        public Int64 OrgID { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(50),
         Display(Name = "Organisation Branch Name")]
        public string OrgBraName { get; set; }
        [DataType(DataType.Text), MaxLength(50)]
        public string OrgBraShort { get; set; }
        //Postal address
        [Required(ErrorMessage = "Address Line 1. is required")]
        [Display(Name = "Postal Address Line 1")]
        public string OrgBraStreet1 { get; set; }
        [Display(Name = "Postal Address Line 2(Optional)")]
        public string OrgBraStreet2 { get; set; }
        [Display(Name = "Postal Address Line 3(Optional)")]
        public string OrgBraStreet3 { get; set; }
        [Display(Name = "Postal Address Line 4(Optional)")]
        public string OrgBraStreet4 { get; set; }
        [Display(Name = "Postal Address Line 5(Optional)")]
        public string OrgBraStreet5 { get; set; }
        [Required]
        [Display(Name = "Province")]
        public string OrgBraProvince { get; set; }
        [Required(ErrorMessage = "Telephone no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Telephone no.")]
        public string OrgBraPhone1 { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Telephone no.")]
        public string OrgBraPhone2 { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Fax no.")]
        public string OrgBraFax { get; set; }
        [Required(ErrorMessage = "Postal Code must be provided")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal Code")]
        public string OrgBraCodeExt { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress), MaxLength(255), Display(Name = "Email Address")]
        public string OrgBraEMailTo { get; set; }
        [Display(Name = "VAT No")]
        public string OrgBraVAT { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long FromDoorID { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress), MaxLength(255)]
        public string OrgBraEMailReg { get; set; }
        public int Order { get; set; }
        public Int64 CollectionID { get; set; }
        public string CDAddressKey { get; set; }


        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<BranchStock> BranchStocks { get; set; }

    }
}