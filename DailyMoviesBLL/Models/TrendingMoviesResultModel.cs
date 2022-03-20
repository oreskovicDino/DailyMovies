namespace DailyMoviesBLL.Models
{
    using System.Collections.Generic;

    public class TrendingMoviesResultModel
    {
        public int page { get; set; }
        public IEnumerable<TrendingMovieModel> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
