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
    [Table("Products")]
    public partial class Product
    {
        public Product()
        {
            ProductImagesx = new HashSet<ProductImages>();
            InvoiceDetails = new HashSet<InvoiceDetails>();
            Features = new HashSet<Features>();
            Specifications = new HashSet<Specifications>();
            ReviewProducts = new HashSet<ReviewProduct>();
            BranchStocks = new HashSet<BranchStock>();
            Wishlists = new HashSet<Wishlist>();
        }
        [Key]
        public Int64 ProdID { get; set; }
        //public string GTIN { get; set; }//Google & Facebook
        public string ProductCode { get; set; }
        //public string ManufCode { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }//LongDescription
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PurchasePrice { get; set; }//PurchasePrice

        #region Price Markups
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceExclVat1 { get; set; }
        public double MarkupUsed1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceExclVat2 { get; set; }
        public double MarkupUsed2 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceExclVat3 { get; set; }
        public double MarkupUsed3 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceExclVat4 { get; set; }
        public double MarkupUsed4 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceExclVat5 { get; set; }
        public double MarkupUsed5 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceExclVat6 { get; set; }
        public double MarkupUsed6 { get; set; }
        #endregion

        //[MaxLength(100)]
        public string GroupName { get; set; }
        //[MaxLength(3800)]
        //public string Notes { get; set; }
        public string UsualAvailability { get; set; }
        //[MaxLength(255)]
        public string URL { get; set; }
        //[MaxLength(255)]
        public string ImgURL { get; set; }
        public short? Status { get; set; }
        public int Warranty { get; set; }
        public bool OutputMe { get; set; }
        public bool Active { get; set; }
        public double StockQty { get; set; }
        //public double DiscQty { get; set; }
        public string Unit { get; set; }
        //Dimensions
        public float? Length { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Mass { get; set; }
        public bool AdwordExclude { get; set; }
        public int DataSource { get; set; }
        //public bool HotDeal { get; set; }//Identifying Hot Deals
        //[DataType(DataType.Date)]
        //[Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, dd MMMM yyyy}")]  
        public DateTime? CreateDate { get; set; }
        
        public string ProductName { get; set; }



        public Int64? OrgID { get; set; }
        public Int64? ManufID { get; set; }//ManuFID
        public Int64? OrgSourceID { get; set; } 
        public Int64? DebitOrderFormID { get; set; }
        public Int64? DeliveryID { get; set; }
        public Int64? MasterProdID { get; set; }
        public int? CategoryID { get; set; }

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
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}