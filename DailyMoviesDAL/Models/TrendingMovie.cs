namespace DailyMoviesDAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TrendingMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public float Vote_Average { get; set; }
        public DateTime Sync_Date { get; set; } = DateTime.Today;

        public MovieDetail MovieDetail { get; set; }
    }
}
