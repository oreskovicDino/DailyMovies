namespace DailyMoviesBLL.Services
{
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Services.Abstractions;
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Repositories.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork unit;

        public GenreService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public async Task<bool> SyncGenre(IEnumerable<GenreModel> genres)
        {
            try
            {
                foreach (var genre in genres)
                {
                    Genre genreDb = new Genre
                    {
                        GenreId= genre.Id,
                        Name = genre.Name
                    };
                    await unit.genre.Upsert(genreDb);
                }
                await unit.CompleteAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
