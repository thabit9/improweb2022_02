using System.Collections.Generic;
using System.Threading.Tasks;
using improweb2022_02.Services.CourierMate.Models;

namespace improweb2022_02.Services.CourierMate
{
    public interface IGlobalData
    {
        string ToUrlEncodedString(Dictionary<string, string> request);
        Dictionary<string, string> ToDictionary(string response);
        Task<List<Town>> GetTowms(Dictionary<string, string> towns);
        Task<List<Servicex>> GetServices(Dictionary<string, string> Service);
        
    } 
}