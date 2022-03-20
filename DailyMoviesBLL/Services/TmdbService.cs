namespace DailyMoviesBLL.Services
{
    using AutoMapper;
    using DailyMoviesBLL.Helper.Abstractions;
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Services.Abstractions;
    using DailyMoviesDAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TmdbService : ITmdbService
    {
        private readonly ITmdbSync tmdbSync;
        private readonly ITrendingMoviesService trendingMoviesService;
        private readonly IMapper mapper;

        private List<MovieCrewModel> CrewModels = new List<MovieCrewModel>();
        private List<MovieCastModel> CastModels = new List<MovieCastModel>();

        public TmdbService(
            ITmdbSync tmdbSync,
            ITrendingMoviesService trendingMoviesService,
            IMapper mapper)
        {
            this.tmdbSync = tmdbSync;
            this.trendingMoviesService = trendingMoviesService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TrendingMovie>> SyncMovies(IFilter filter)
        {
            try
            {
                if (!await trendingMoviesService.CheckSyncStatus())
                {
                    await trendingMoviesService.RemoveStaleMovies();


                    TrendingMoviesResultModel trendingResults = await tmdbSync.SyncTrandingDaily(1);

                    foreach (var trendingMovie in trendingResults.Results)
                    {
                        //Save list of trending movies
                        //TrendingMovie
                        MovieDetail detaildMovie = await SyncMovieDetails(trendingMovie.Id);
                        TrendingMovie trendingMovieDb = mapper.Map<TrendingMovie>(trendingMovie);
                        detaildMovie.MovieId = trendingMovieDb.MovieId;
                        trendingMovieDb.MovieDetail = detaildMovie;
                        
                        await trendingMoviesService.InsertTrendingMovie(trendingMovieDb);
                    }

                    return await trendingMoviesService.GetTrendingMoviesAsync(filter);
                }
                else
                {
                    return await trendingMoviesService.GetTrendingMoviesAsync(filter);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<MovieDetail> SyncMovieDetails(int movieId)
        {

            try
            {
                MovieDetailModel movieDetails = await tmdbSync.MovieSync(movieId);

                MovieDetail movieDetail = mapper.Map<MovieDetail>(movieDetails);
                await SyncProdcutionCrew(movieId);

                movieDetail.Crew = mapper.Map<List<Crew>>(CrewModels);
                movieDetail.Cast = mapper.Map<List<Cast>>(CastModels);

                return movieDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<bool> SyncProdcutionCrew(int movieId)
        {
            try
            {
                var production = await tmdbSync.CreditsSync(movieId);

                foreach (var crew in production.Crew.Where(x => x.Job == "Director"))
                {
                    var person = await tmdbSync.PersonSync(crew.Id);
                    CrewModels.Add(mapper.Map<MovieCrewModel>(person));
                }

                foreach (var cast in production.Cast.Where(x => x.Order < 10))
                {
                    var person = await tmdbSync.PersonSync(cast.Id);
                    CastModels.Add(mapper.Map<MovieCastModel>(person));
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
