using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace improweb2022_02.Services.CourierMate
{
    public class CourierMateService
    {
        public static CourierMateConfig getCourierConfig()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var _configuration = builder.Build();
            return new CourierMateConfig(){
                End_Point = _configuration["CourierMate:End_point"],
                Username = _configuration["CourierMate:Username"],
                Password = _configuration["CourierMate:Password"]
            };
        }
    }
}