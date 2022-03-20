namespace DailyMoviesDAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Crew
    {
        public int Id { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Known_For_Department { get; set; }

        [MaxLength(30)]
        public string Job { get; set; }


        //Relations config
        public MovieDetail MovieDetail { get; set; }
    }
}
