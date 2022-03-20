namespace DailyMoviesDAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TrendingMovie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int MovieId { get; set; }
        public float Vote_Average { get; set; }
        public DateTime Sync_Date { get; set; } = DateTime.Today;

        public MovieDetail MovieDetail { get; set; }
    }
}
