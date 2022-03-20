namespace DailyMoviesApp.Helpers
{
    using AutoMapper;
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Models.Dtos;
    using DailyMoviesDAL.Models;
    using DailyMoviesDAL.Models.Dtos;
    using System;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TrendingMovieModel, TrendingMovie>()
                .ForMember(a => a.MovieId, b => b.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<MovieDetailModel, MovieDetail>()
                .ForMember(a => a.MovieId, b => b.MapFrom(src => src.Id))
                .ForMember(a => a.Genre, b => b.MapFrom(src => src.Genres))
                .ForMember(a => a.Release_Date, b => b.MapFrom(src => Convert.ToDateTime(src.Release_Date))).ReverseMap();

            CreateMap<TrendingMoviesDto, MovieDetail>().ReverseMap();

            CreateMap<MovieCrewModel, PersonModel>()
                .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
            CreateMap<MovieCastModel, PersonModel>()
                 .ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
            
            
            CreateMap<MovieCrewModel, Crew>().ReverseMap();
            CreateMap<MovieCastModel, Cast>().ReverseMap();


            CreateMap<PersonModel, MovieCrewModel>().ReverseMap();

            CreateMap<CastDto, Cast>().ReverseMap();
            CreateMap<CrewDto, Crew>().ReverseMap();
        }
    }
}
