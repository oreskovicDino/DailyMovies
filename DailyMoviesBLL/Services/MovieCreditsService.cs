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

        //public async Task<ProductionDto> SyncCreditsByMovie(int movieId)
        //{
        //    try
        //    {
        //        MovieCreditsModel movieCreditsModel = await tmdbSync.CreditsSync(movieId);
        //        List<Cast> castsDb = new List<Cast>();
        //        List<Crew> crewsDb = new List<Crew>();


        //        foreach (var cast in movieCreditsModel.Cast.Where(x => x.Order < 10))
        //        {
        //            PersonModel person = await tmdbSync.PersonSync(cast.Id);
        //            Cast castDb = new Cast
        //            {
        //                Id = cast.Id,
        //                Character = cast.Character,
        //                Known_For_Department = cast.Known_For_Department,
        //                Order = cast.Order,
        //                MovieDetailId = movieId
        //            };
        //            castsDb.Add(castDb);
        //        }

        //        foreach (var crew in movieCreditsModel.Crew.Where(x => x.Job == "Director"))
        //        {
        //            PersonModel person = await tmdbSync.PersonSync(crew.Id);
        //            Crew crewDb = new Crew
        //            {
        //                Id = crew.Id,
        //                Job = crew.Job,
        //                Known_For_Department = crew.Known_For_Department,
        //                Order = crew.Order,
        //                MovieDetailId = movieId
        //            };
        //            crewsDb.Add(crewDb);
        //        }

        //        return new ProductionDto
        //        {
        //            Crews = crewsDb,
        //            Casts = castsDb
        //        };

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
