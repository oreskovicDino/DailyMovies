namespace DailyMoviesBLL.Models
{
    using System.Collections.Generic;

    public class MovieDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public string Backdrop_Path { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; }
        public string Release_Date { get; set; }
    }
}
