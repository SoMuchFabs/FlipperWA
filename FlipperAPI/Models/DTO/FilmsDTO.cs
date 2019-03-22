using System;
using System.Collections;
using System.Collections.Generic;

namespace FlipperAPI.Models.DTO
{
    public class FilmsDTO
    {
        public decimal IdFilm { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Actors { get; set; }
        public decimal Duration { get; set; }
        public IEnumerable<string> ScreeningDate { get; set; }
        public string PosterUrl { get; set; }
        public string Plot { get; set; }
    }
}