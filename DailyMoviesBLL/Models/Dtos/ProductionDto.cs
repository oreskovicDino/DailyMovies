namespace DailyMoviesBLL.Models.Dtos
{
    using DailyMoviesDAL.Models;
    using System.Collections.Generic;

    public class ProductionDto
    {
        public ICollection<Crew> Crews { get; set; }
        public ICollection<Cast> Casts { get; set; }
    }
}
