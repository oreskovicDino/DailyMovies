namespace DailyMoviesBLL.Models
{
    using System.Collections.Generic;

    public class MovieCreditsModel
    {
        public int Id { get; set; }
        public IEnumerable<MovieCastModel> Cast { get; set; }
        public IEnumerable<MovieCrewModel> Crew { get; set; }
    }
}
