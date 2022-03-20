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


        //public override async Task<bool> Upsert(Genre genre)
        //{
        //    try
        //    {
        //        var existingGenre = await dbSet.Where(x => x.Id == genre.Id).FirstOrDefaultAsync();

        //        if (existingGenre is null)
        //        {
        //            return await Add(genre);
        //        }
        //        else
        //        {
        //            existingGenre.Id = genre.Id;
        //            existingGenre.Name = genre.Name;
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
