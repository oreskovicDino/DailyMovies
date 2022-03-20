
namespace DailyMoviesDAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        //Relations config
        public MovieDetail MovieDetail { get; set; }
    }
}
