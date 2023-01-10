using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace improweb2022_02.PayPal
{
    public class PayPalConfig
    {
        public string AuthToken { get; set; }
        public string PostUrl { get; set; }
        public string Business { get; set; }
        public string ReturnUrl { get; set; }
    }
}