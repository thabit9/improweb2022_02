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
                CurrencyFormat2 = _configuration["appSettings:CurrencyFormat_backup"]
            };
        }
    }
}