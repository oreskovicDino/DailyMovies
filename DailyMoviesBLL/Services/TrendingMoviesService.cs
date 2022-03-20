namespace DailyMoviesBLL.Services
{
    using AutoMapper;
    using DailyMoviesBLL.Helper.Abstractions;
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Services.Abstractions;
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Repositories.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TrendingMoviesService : ITrendingMoviesService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMovieDetailsService movieDetailsService;
        private readonly IMapper mapper;
        private readonly ITmdbSync tmdbSync;

        public TrendingMoviesService(
            IUnitOfWork unitOfWork,
            IMovieDetailsService movieDetailsService,
            IMapper mapper,
            IUnitOfWork unitOfWork1,
            ITmdbSync tmdbSync
            )
        {
            this.unitOfWork = unitOfWork;
            this.movieDetailsService = movieDetailsService;
            this.mapper = mapper;
            this.tmdbSync = tmdbSync;
        }



        public async Task<bool> InsertTrendingMovie(TrendingMovie trendingMovie)
        {
            try
            {
                await unitOfWork.trendingMovies.Add(trendingMovie);
                await unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // TODO: Complete CRUD for the trending movie repository.

        /// <summary>
        /// Removes old movies
        /// </summary>
        public async Task<bool> RemoveStaleMovies()
        {
            try
            {
                List<TrendingMovie> oldmovies = await unitOfWork.trendingMovies.GetOldMovies();
                if (oldmovies.Count > 0)
                {
                    unitOfWork.trendingMovies.DeleteRange(oldmovies);
                    await unitOfWork.CompleteAsync();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Resolves formatted list of trending movies
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TrendingMovie>> GetTrendingMoviesAsync(IFilter filter)
        {
            try
            {
              return await unitOfWork.trendingMovies.GetTrendingMovies(filter.FilterString);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method checks if trending movies were synced today.
        /// </summary>
        /// <returns><typeparam name="true"> if there are movies synced today. <typeparam name="false"> otherwise</returns>
        public async Task<bool> CheckSyncStatus()
        {
            try
            {
                await unitOfWork.trendingMovies.MovieSyncStatus();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}