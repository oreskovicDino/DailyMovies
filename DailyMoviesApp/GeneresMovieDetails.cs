namespace DailyMoviesApp
{
    using DailyMoviesDAL.Models;

    public class GeneresMovieDetails
    {
        public int Id { get; set; }

        public int MovieDetailId { get; set; }
        public MovieDetail MovieDetail{ get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
