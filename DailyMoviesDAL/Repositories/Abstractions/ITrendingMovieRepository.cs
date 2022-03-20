namespace DailyMoviesDAL.Repositories.Abstractions
{
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Models.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrendingMovieRepository : IGenericRepository<TrendingMovie>
    {
        Task<bool> CreateRangeAsync(IEnumerable<TrendingMovie> trendingMovies);
        bool DeleteRange(IEnumerable<TrendingMovie> movies);
        Task<List<TrendingMovie>> GetOldMovies();
        Task<IEnumerable<TrendingMovie>> GetTrendingMovies(string filter);
        Task<bool> MovieSyncStatus();
    }
}
