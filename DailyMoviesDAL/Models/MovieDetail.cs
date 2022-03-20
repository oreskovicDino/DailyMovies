namespace DailyMoviesDAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MovieDetail
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        [MaxLength(80)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Overview { get; set; }

        [MaxLength(100)]
        public string Tagline { get; set; }

        public DateTime Release_Date { get; set; }

        [MaxLength(100)]
        public string Backdrop_Path { get; set; }

        //Relations config
        [ForeignKey("TrendingMovie")]
        public int TrendingMovieId { get; set; }
        public TrendingMovie TrendingMovie { get; set; }

        public ICollection<Crew> Crew { get; set; }
        public ICollection<Cast> Cast { get; set; }
        public ICollection<Genre> Genre { get; set; }

    }
}
