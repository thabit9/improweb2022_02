namespace improweb2022_02.Services.CourierMate.Models
{
    public class Town
    {
        public int id { get; set; }
        public string town_name { get; set; }
        public string postal_code { get; set; }
        public int regional { get; set; }
        public int surcharge { get; set; }
        public string area_name { get; set; }
        public string area_code { get; set; }
    }
}