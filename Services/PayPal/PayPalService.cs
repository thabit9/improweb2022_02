using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.PayPal
{
    public class PayPalService
    {
        public static PayPalConfig getPayPalConfig()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var _configuration = builder.Build();
            return new PayPalConfig(){
                AuthToken = _configuration["PayPal:AuthToken"],
                PostUrl = _configuration["PayPal:PostUrl"],
                Business = _configuration["PayPal:Business"],
                ReturnUrl = _configuration["PayPal:ReturnUrl"]
            };
        }
    }
}