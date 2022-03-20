namespace DailyMoviesDAL.Repositories
{
    using DailyMoviesDAL.DataAccess;
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Repositories.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TrendingMovieRepository : GenericRepository<TrendingMovie>, ITrendingMovieRepository
    {
        private readonly ILogger logger;

        public TrendingMovieRepository(ApplicationDbContex contex, ILogger logger) : base(contex, logger)
        {
            this.logger = logger;
        }

        public async Task<bool> CreateRangeAsync(IEnumerable<TrendingMovie> trendingMovies)
        {
            try
            {
                await dbSet.AddRangeAsync(trendingMovies);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "{Repo} \"CreateRangeAsync\" method error", typeof(TrendingMovieRepository));
                return false;
            }
        }

        public override async Task<bool> Upsert(TrendingMovie movie)
        {
            try
            {
                var existingMovie = await dbSet.Where(x => x.MovieId == movie.MovieId).FirstOrDefaultAsync();

                if (existingMovie is null)
                {
                    return await Add(movie);
                }
                else
                {
                    existingMovie = movie;
                    return true;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "{Repo} \"Upsert\" method error", typeof(TrendingMovieRepository));
                return false;
            }
        }

        public override bool Delete(TrendingMovie movie)
        {
            try
            {
                if (movie is not null)
                {
                    dbSet.Remove(movie);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "{Repo} \"Delete\" method error", typeof(TrendingMovieRepository));
                return false;
            }
        }

        public async Task<List<TrendingMovie>> GetOldMovies()
        {
            try
            {
                return await dbSet.Where(x => x.Sync_Date < DateTime.Now).ToListAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, "{Repo} \"GetSyncDate\" method error", typeof(TrendingMovieRepository));
                return new List<TrendingMovie>();
            }
        }

        /// <summary>
        /// Checks if movies were synced today.
        /// </summary>
        /// <returns><typeparam name="true"> if there are movies synced today. <typeparam name="false"> otherwise</returns>
        public async Task<bool> MovieSyncStatus()
        {
            try
            {
                var count = await dbSet.Where(x => x.Sync_Date == DateTime.Today).ToListAsync();
                return count.Count > 0;
            }
            catch (Exception e)
            {
                logger.LogError(e, "{Repo} \"MovieSyncStatus\" method error", typeof(TrendingMovieRepository));
                return false;
            }
        }

        public bool DeleteRange(IEnumerable<TrendingMovie> movies)
        {
            try
            {
                dbSet.RemoveRange(movies);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "{Repo} \"DeleteRange\" method error", typeof(TrendingMovieRepository));
                return false;
            }
        }


        public async Task<IEnumerable<TrendingMovie>> GetTrendingMovies(string filter)
        {
            try
            {
                return await dbSet.Where(x => x.MovieDetail.Title == filter).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
