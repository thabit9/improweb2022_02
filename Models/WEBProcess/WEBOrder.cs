using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBOrders")]
    public class WEBOrder
    {
        public WEBOrder()
        {
        }

        [Key]
        public Int64 OrderID { get; set; }
        public Int64 CustID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }
        public string DeliveryMethod { get; set; }
        public Int64 DeliveryDescID { get; set; }
        [Display(Name = "Delivery Cost"), 
         DataType(DataType.Currency)]
        public double DeliveryCost { get; set; }
        public Int64 PayID { get; set; }
        public Int64 StatusID { get; set; }
        public string Notes { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public Int64 ShippingID { get; set; }
        public Int64 OrgID { get; set; }
        public Int64 OrgBranchID { get; set; }
        public bool? Insuarance { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public string DeliveryQuoteID { get; set; }
        public Int16 DistOrdStatus { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress), MaxLength(255),
         Display(Name = "Review Email Address")]
        public string ReviewEmailSent { get; set; }
        //From courier service will need to communicate with the service to get this ID
        public Int64 DeliveryWaybillID { get; set; }
        public string CustRef { get; set; }
        public string DiscountRefCode { get; set; }
        [Display(Name = "Discount"), 
         DataType(DataType.Currency)]
        public double Discount { get; set; }
        public Int64 DeliveryID { get; set; }

        //Must add this option to the database
        //[Display(Name = "Order Total"), DataType(DataType.Currency)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal OrderTotal { get; set; }

        //WEBCustomer Details
        [ForeignKey(nameof(CustID))]
        public Customer Customer { get; set; }
        /*[ForeignKey(nameof(DeliveryDescID))]
        public WEBDeliveryDesc DeliveryDescNavigation { get; set; }
        [ForeignKey(nameof(PayID))]
        public WEBPayMethod PayMethodNavigation { get; set; }
        [ForeignKey(nameof(StatusID))]
        public WEBOrderStatus OrderStatusNavigation { get; set; }
        [ForeignKey(nameof(ShippingID))]
        public WEBShipping ShippingNavigation { get; set; }
        [ForeignKey(nameof(OrgID))]
        public Organisation OrganisationNavigation { get; set; }
        [ForeignKey(nameof(OrgBranchID))]
        public OrganisationBranch OrgBranchNavigation { get; set; }
        [ForeignKey(nameof(DeliveryID))]
        public WEBDelivery DeliveryNavigation { get; set; }*/

        public virtual List<WEBOrderItems> WEBOrderItemx { get; set; }
    }
}