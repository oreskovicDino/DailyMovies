namespace DailyMoviesDAL.Models.Dtos
{
    using System;
    using System.Collections.Generic;

    public class TrendingMoviesDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public DateTime Release_Date { get; set; }
        public string Backdrop_Path { get; set; }
        public double Vote_Average { get; set; }
        public IEnumerable<Cast> Casts { get; set; }
        public IEnumerable<Crew> Crews { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
