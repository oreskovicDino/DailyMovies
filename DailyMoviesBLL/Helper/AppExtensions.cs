namespace DailyMoviesBLL.Helper
{
    using AutoMapper;
    using DailyMoviesDAL.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class AppExtensions
    {
        public static IServiceCollection SetUpAppDependencies(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ApplicationDbContex>(options => options.UseSqlServer(connectionString));
            return serviceCollection;
        }
    }
}
