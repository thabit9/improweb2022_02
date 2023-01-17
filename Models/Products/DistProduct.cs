using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.Models
{
    [Table("DistProducts")]
    public partial class DistProduct
    {
        public DistProduct()
        {
            /*ProductImagesx = new HashSet<ProductImages>();
            InvoiceDetails = new HashSet<InvoiceDetails>();
            Features = new HashSet<Features>();
            Specifications = new HashSet<Specifications>();
            ReviewProducts = new HashSet<ReviewProduct>();
            BranchStocks = new HashSet<BranchStock>();
            Wishlists = new HashSet<Wishlist>();*/
        }
        [Key]
        public Int64 DistProdID { get; set; }
        //public string GTIN { get; set; }//Google & Facebook
        public string ProductCode { get; set; }
        //public string ManufCode { get; set; }
        public string ProdDescription { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price2 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price3 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price4 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price5 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price6 { get; set; }
        public string UsualAvailability { get; set; }
        public string Brand { get; set; }
        public string BrandLogo { get; set; }
        public int Warranty { get; set; }
        public short? Status { get; set; }
        public string URL { get; set; }
        public string ImgURL { get; set; }
        public double StockQty { get; set; }
        public string GroupName { get; set; }



        public Int64? OrgID { get; set; }
        /*public Int64? ManufID { get; set; }//ManuFID
        public Int64? OrgSourceID { get; set; }
        public Int64? DebitOrderFormID { get; set; }
        public Int64? DeliveryID { get; set; }
        public Int64? MasterProdID { get; set; }
        public int CategoryID { get; set; }

        public virtual Organisation Organisation { get; set; }       
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual OrganisationSource Source { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BranchStock> BranchStocks { get; set; }
        public virtual ICollection<ProductImages> ProductImagesx { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual ICollection<Features> Features { get; set; }
        public virtual ICollection<Specifications> Specifications { get; set; }
        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }*/
    }
}