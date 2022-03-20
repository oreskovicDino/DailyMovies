namespace DailyMoviesDAL.DataAccess
{
    using DailyMoviesDAL.Repositories;
    using DailyMoviesDAL.Repositories.Abstractions;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContex contex;
        private readonly ILogger logger;

        public ITrendingMovieRepository trendingMovies { get; private set; }
        public IMovieDetailRepository movieDetail { get; private set; }
        public IGenreRepository genre{ get; private set; }

        public UnitOfWork( ApplicationDbContex contex, ILoggerFactory loggerFactory)
        {
            this.contex = contex;
            this.logger = loggerFactory.CreateLogger("logs");

            trendingMovies = new TrendingMovieRepository(contex, logger);
            movieDetail = new MovieDetailRepository(contex, logger);
            genre = new GenreRepository(contex, logger);
        }

        public async Task CompleteAsync()
        {
            await contex.SaveChangesAsync();
        }

        public void Dispose()
        {
            contex.Dispose();
        }

    }
}
