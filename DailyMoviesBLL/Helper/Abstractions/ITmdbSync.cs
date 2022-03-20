namespace DailyMoviesBLL.Helper.Abstractions
{
    using DailyMoviesBLL.Models;
    using System.Threading.Tasks;

    public interface ITmdbSync
    {
        Task<TrendingMoviesResultModel> SyncTrandingDaily(int currentPage);
        Task<MovieDetailModel> MovieSync(int movieId);
        Task<MovieCreditsModel> CreditsSync(int movieId);
        Task<PersonModel> PersonSync(int personId);
    }
}