namespace DailyMoviesBLL.Services
{
    using AutoMapper;
    using DailyMoviesBLL.Helper.Abstractions;
    using DailyMoviesBLL.Models.Dtos;
    using DailyMoviesBLL.Services.Abstractions;
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Repositories.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MovieDetailsService : IMovieDetailsService
    {
        private readonly ITmdbSync tmdbSync;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMovieCreditsService movieCreditsService;

        public MovieDetailsService(
            ITmdbSync tmdbSync,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMovieCreditsService movieCreditsService)
        {
            this.tmdbSync = tmdbSync;
            this.unitOfWork = unitOfWork;
            this.movieCreditsService = movieCreditsService;
        }

        // TODO: Implement CRUD for the MovieDetails repository.
    }
}
