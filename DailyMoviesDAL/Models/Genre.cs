
namespace DailyMoviesDAL.Models
{
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int GenreId { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        //Relations config
        public MovieDetail MovieDetail { get; set; }
    }
}
