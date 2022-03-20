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

        //public async Task<MovieDetail> UpsertMovieDetail(int movieId)
        //{
        //    try
        //    {
        //        var movieDetail = await tmdbSync.MovieSync(movieId);

        //        List<MovieDetailGenre> movieDetailGenres = new List<MovieDetailGenre>();

        //        foreach (var genre in movieDetail.Genres)
        //        {
        //            MovieDetailGenre movieDetailGenre = new MovieDetailGenre
        //            {
        //                GenreId = genre.Id,
        //                MovieDetailId = movieDetail.Id
        //            };
        //            movieDetailGenres.Add(movieDetailGenre);
        //        }

        //        ProductionDto production = await movieCreditsService.SyncCreditsByMovie(movieId);

        //        MovieDetail movieDetailData = new MovieDetail
        //        {
        //            MovieId = movieDetail.Id,
        //            Title = movieDetail.Title,
        //            Tagline = movieDetail.Tagline,
        //            Release_Date = DateTime.Parse(movieDetail.Release_Date),
        //            Backdrop_Path = movieDetail.Backdrop_Path,
        //            MovieDetailGenre = movieDetailGenres,
        //            Casts = production.Casts,
        //            Crews = production.Crews
        //        };

        //        //if ())
        //        //{
        //        //    return movieDetailData;
        //        //}

        //        await unitOfWork.movieDetail.Upsert(movieDetailData);
        //        return movieDetailData;

        //        //throw new ArgumentNullException();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
