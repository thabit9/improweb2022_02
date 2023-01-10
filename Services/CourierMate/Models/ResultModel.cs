using System.Collections.Generic;

namespace improweb2022_02.Services.CourierMate.Models
{
    public class ResultModel
    {
        public string response_message { get; set; }
        public int response_code { get; set; }
        public int record_count { get; set; }
        public List<Town> records { get; set; }
        public List<Servicex> servicex { get; set; }
    }
}