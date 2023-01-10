using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using improweb2022_02.DataAccess;
using improweb2022_02.Services.CourierMate;
using improweb2022_02.Services.CourierMate.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Configuration;

namespace improweb2022_02.Services.CourierMate
{
    public class GlobalData: IGlobalData
    {
        private improwebContext _db;
        //private IGlobalData _globalData = new GlobalData();
        public GlobalData()
        {
            _db = new improwebContext();
        }

        #region Utilities
        /** Encode dictionary to Url string */
        public string ToUrlEncodedString(Dictionary<string, string> request)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string key in request.Keys)
            {
                builder.Append("&");
                builder.Append(key);
                builder.Append("=");
                builder.Append(HttpUtility.UrlEncode(request[key]));
            }

            string result = builder.ToString().TrimStart('&');

            return result;
        }

        /** Convert query string to dictionary */
        public Dictionary<string, string> ToDictionary(string response)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string[] valuePairs = response.Split('&');
            foreach (string valuePair in valuePairs)
            {
                string[] values = valuePair.Split('=');
                result.Add(values[0], HttpUtility.UrlDecode(values[1]));
            }

            return result;
        }
        #endregion Utility

        public async Task<List<Town>> GetTowms(Dictionary<string, string> towns)
        {   
            CourierMateConfig _configuration = CourierMateService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            List<Town> _towns = new List<Town>();
            HttpClient http = new HttpClient();
            Dictionary<string, string> request = new Dictionary<string, string>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_towns");
            request.Add("town_name", towns["town_name"]);
            request.Add("postal_code", towns["postal_code"]);

            string requestString = /*_globalData.*/ToUrlEncodedString(request);
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestString), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            // if the request did not succeed, this line will make the program crash
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                //Dictionary<string, string> results = _payment.ToDictionary(responseContent);
                var result = JsonConvert.DeserializeObject<ResultModel>(responseContent);
                
                if (result.response_code == 0 && result.record_count != 0)
                {   
                    _towns = result.records;
                }
            }
            return _towns;  
        }

        public async Task<List<Servicex>> GetServices(Dictionary<string, string> servicex)
        {   
            CourierMateConfig _configuration = CourierMateService.getCourierConfig();
            var end_point = _configuration.End_Point;
            var username  = _configuration.Username;
            var password  = _configuration.Password;

            List<Servicex> _services = new List<Servicex>();
            HttpClient http = new HttpClient();
            Dictionary<string, string> request = new Dictionary<string, string>();
            request.Add("username", username);
            request.Add("password", password);
            request.Add("method", "get_towns");
            request.Add("town_name", servicex["town_name"]);
            request.Add("postal_code", servicex["postal_code"]);

            string requestString = /*_globalData.*/ToUrlEncodedString(request);
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestString), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(end_point, content);
            // if the request did not succeed, this line will make the program crash
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                //Dictionary<string, string> results = _payment.ToDictionary(responseContent);
                var result = JsonConvert.DeserializeObject<ResultModel>(responseContent);
                
                if (result.response_code == 0 && result.record_count != 0)
                {   
                    _services = result.servicex;
                }
            }
            return _services;  
        }


    }
}