using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlipperAPI.Models
{
    public class ReservationBindingModel
    {
        [Required]
        public decimal ID_SCREENING { get; set; }

        [Required]
        public DateTime? RESERVATION_DATE { get; set; }

        [Required]
        public decimal ID_SEAT { get; set; }

        [Required]
        public bool IS_REDUCED { get; set; }
    }
}