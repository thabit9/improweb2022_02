using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace improweb2022_02.Helpers
{
    public class WebConfig
    {
        public long OrgID { get; set; }
        public string CurrencyFormat { get; set; }
        public string CurrencyFormat2 { get; set; }
        public string internetExpressWebID { get; set; }
        public string DefaultPrice { get; set; }
        public string AdminEmail { get; set; }
        public string OrderEmail { get; set; }
        public string ShippingEmail { get; set; }
        public string BrandsPerLine { get; set; }
        public string BrandsLine { get; set; }
        public string BrandLineSplit { get; set; }
        public string SiteName { get; set; }
    }
}