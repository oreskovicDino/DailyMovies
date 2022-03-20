namespace DailyMoviesBLL.Services.Abstractions
{
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Models.Dtos;
    using DailyMoviesDAL.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrendingMoviesService
    {
        Task<bool> CheckSyncStatus();
        Task<IEnumerable<TrendingMovie>> GetTrendingMoviesAsync(IFilter filter);
        Task<bool> InsertTrendingMovie(TrendingMovie trendingMovie);
        Task<bool> RemoveStaleMovies();
    }
}