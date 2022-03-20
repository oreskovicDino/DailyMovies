namespace DailyMoviesBLL.Helper
{
    using DailyMoviesBLL.Helper.Abstractions;
    using DailyMoviesBLL.Models;
    using System;
    using System.Threading.Tasks;

    public class TmdbSync : ITmdbSync
    {
        /// <summary>
        /// TMDB request path section for requesting trending movies in a day.
        /// </summary>
        private const string TrandingDailyUriPath = "trending/movie/day?";

        private readonly TmdbClient client;

        public TmdbSync(TmdbClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public async Task<TrendingMoviesResultModel> SyncTrandingDaily(int currentPage)
        {
            try
            {
                return await client.GetRequestAsync<TrendingMoviesResultModel>($"{TrandingDailyUriPath}page={currentPage}&");
            }
            catch (Exception){throw;}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<MovieDetailModel> MovieSync(int movieId)
        {
            try
            {
                return await client.GetRequestAsync<MovieDetailModel>($"movie/{movieId}?");
            }
            catch (Exception){throw;}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<MovieCreditsModel> CreditsSync(int movieId)
        {
            try
            {
                return await client.GetRequestAsync<MovieCreditsModel>($"movie/{movieId}/credits?");
            }
            catch (Exception){throw;}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<PersonModel> PersonSync(int personId)
        {
            try
            {
                return await client.GetRequestAsync<PersonModel>($"person/{personId}?");
            }
            catch (Exception e){throw;}
        }
    }
}
