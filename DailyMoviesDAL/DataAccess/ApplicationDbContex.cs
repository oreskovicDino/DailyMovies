namespace DailyMoviesDAL.DataAccess
{
    using DailyMoviesDAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContex : DbContext
    {
        public virtual DbSet<TrendingMovie> TrendingMovie { get; set; }
        public virtual DbSet<MovieDetail> MovieDetail { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Cast> Cast { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }

        public ApplicationDbContex(DbContextOptions options) : base(options) { }
    }
}
