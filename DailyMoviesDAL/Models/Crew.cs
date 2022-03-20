namespace DailyMoviesDAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Crew
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CrewId { get; set; }

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
