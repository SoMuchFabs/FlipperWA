using System;

namespace FlipperAPI.Models.DTO
{
    public class FilmsDTO
    {
        public string Title { get; set; }
        public string Genres { get; set; }
        public DateTime RelaseDate { get; set; }
        public string Actors { get; set; }
        public decimal Duration { get; set; }
        public DateTime ScreeningDate { get; set; }
        public string PosterUrl { get; set; }
        public string Plot { get; set; }
        public bool inProiezione { get; set; }
    }
}