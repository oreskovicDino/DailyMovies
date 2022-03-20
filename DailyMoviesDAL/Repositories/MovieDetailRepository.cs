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


        //public override async Task<bool> Upsert(MovieDetail movieDetail)
        //{
        //    try
        //    {
        //        var existingMovieDetail = await dbSet.Where(x => x.Id == movieDetail.Id).FirstOrDefaultAsync();

        //        if (existingMovieDetail is null)
        //        {
        //            return await Add(movieDetail);
        //        }
        //        else
        //        {
        //            existingMovieDetail.Title = movieDetail.Title;
        //            existingMovieDetail.Tagline = movieDetail.Tagline;
        //            existingMovieDetail.Overview = movieDetail.Overview;
        //            existingMovieDetail.Release_Date = movieDetail.Release_Date;
        //            existingMovieDetail.Backdrop_Path = movieDetail.Backdrop_Path;

        //            return true;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError(e, "{Repo} \"Upsert\" method error", typeof(MovieDetailRepository));
        //        return false;
        //    }
        //}
    }
}
