namespace DailyMoviesDAL.Repositories
{
    using DailyMoviesDAL.DataAccess;
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Repositories.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class MovieDetailRepository : GenericRepository<MovieDetail>, IMovieDetailRepository
    {
        private readonly ILogger logger;

        public MovieDetailRepository(ApplicationDbContex contex, ILogger logger) : base(contex, logger)
        {
            this.logger = logger;
        }

        // TODO: Implement CRUD for the MovieDetail repository.
    }
}
