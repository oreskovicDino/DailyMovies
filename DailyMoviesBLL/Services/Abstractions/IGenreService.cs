namespace DailyMoviesBLL.Services.Abstractions
{
    using DailyMoviesBLL.Models;
    using DailyMoviesDAL.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenreService
    {
        Task<bool> SyncGenre(IEnumerable<GenreModel> genres);
    }
}