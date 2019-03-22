using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlipperAPI.Models.DTO
{
    public class SeatsDTO
    {
        public decimal Id_seats { get; set; }
        public string Code { get; set; }
        public decimal Id_theater { get; set; }
        public bool Stolen { get; set; }
    }
}