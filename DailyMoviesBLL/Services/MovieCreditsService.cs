namespace DailyMoviesBLL.Services
{
    using DailyMoviesBLL.Helper.Abstractions;
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Models.Dtos;
    using DailyMoviesBLL.Services.Abstractions;
    using DailyMoviesDAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MovieCreditsService : IMovieCreditsService
    {
        private readonly ITmdbSync tmdbSync;

        public MovieCreditsService(
            ITmdbSync tmdbSync)
        {
            this.tmdbSync = tmdbSync;
        }

        // TODO: Implement CRUD for the Crew repository.
        // TODO: Implement CRUD for the Cast repository.
    }
}
