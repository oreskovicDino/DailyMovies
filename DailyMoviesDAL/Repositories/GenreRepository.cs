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

    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly ILogger logger;

        public GenreRepository(
            ApplicationDbContex contex,
            ILogger logger) : base(contex, logger)
        {
        }
    

        // TODO: Implement CRUD for the Genre repository.
    }
}
