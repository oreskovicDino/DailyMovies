namespace DailyMoviesDAL.Repositories.Abstractions
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        ITrendingMovieRepository trendingMovies { get; }
        IMovieDetailRepository movieDetail { get; }
        IGenreRepository genre { get; }

        Task CompleteAsync();
    }
}
