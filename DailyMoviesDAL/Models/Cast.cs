namespace DailyMoviesDAL.Models
{
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Cast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CastId { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Known_For_Department { get; set; }

        [MaxLength(30)]
        public string Character { get; set; }


        //Relations config
        public MovieDetail MovieDetail { get; set; }
    }
}
