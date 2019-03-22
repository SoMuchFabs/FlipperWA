using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlipperAPI.Models.DTO
{
    public class ScreeningsDTO
    {
        public decimal Id_screening { get; set; }
        public DateTime Screening_date { get; set; }
        public decimal? Price { get; set; }
        public decimal? Reduced_price { get; set; }
        public decimal Id_theater { get; set; }
        public string Theater_Name { get; set; }
    }
}
