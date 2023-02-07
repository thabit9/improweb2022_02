using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.Helpers
{
    public class WebConfigService
    {
        public static WebConfig getWebConfig()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var _configuration = builder.Build();
            return new WebConfig(){
                OrgID = long.Parse(_configuration["appSettings:OrgID"]),
                CurrencyFormat = _configuration["appSettings:CurrencyFormat"],
                CurrencyFormat2 = _configuration["appSettings:CurrencyFormat_backup"],
                internetExpressWebID = _configuration["GlobalSettings:internetExpressWebID"],
                DefaultPrice = _configuration["appSettings:DefaultPrice"],
                AdminEmail = _configuration["appSettings:AdminEmail"],
                OrderEmail = _configuration["appSettings:OrderEmail"],
                ShippingEmail = _configuration["appSettings:ShippingEmail"],
                BrandsPerLine = _configuration["appSettings:BrandsPerLine"],
                BrandsLine = _configuration["appSettings:BrandsLine"],
                BrandLineSplit = _configuration["appSettings:BrandLineSplit"],
                SiteName = _configuration["appSettings:SiteName"],
                ConnectionString = _configuration["ConnectionStrings:improwebDbContextCon"],
                ShowLowStockNumber = int.Parse(_configuration["appSettings:ShowLowStockNumber"])
            };
        }
    }
}