namespace DailyMoviesBLL.Services.Abstractions
{
    using DailyMoviesBLL.Models;
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Models.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITmdbService
    {
        Task<IEnumerable<TrendingMovie>> SyncMovies(IFilter filter);
    }
}