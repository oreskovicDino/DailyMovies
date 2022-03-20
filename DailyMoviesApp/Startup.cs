namespace DailyMoviesApp
{
    using DailyMoviesApp.Helpers;
    using DailyMoviesBLL.Helper;
    using DailyMoviesBLL.Helper.Abstractions;
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Services;
    using DailyMoviesBLL.Services.Abstractions;
    using DailyMoviesDAL.DataAccess;
    using DailyMoviesDAL.Repositories.Abstractions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppOptions>(options => Configuration.Bind(options));

            // Db Connection
            services.SetUpAppDependencies(Configuration.GetConnectionString("SomeConnection2"));
            //services.AddDbContext<ApplicationDbContex>(
            //    options =>
            //    {
            //        options.UseSqlServer(Configuration["ConnectionStrings:SomeConnection2"]);
            //        //options.EnableSensitiveDataLogging();
            //    });

            #region AutoMapper Init
            var configMapper = new AutoMapper.MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfiles()); });
            var mapper = configMapper.CreateMapper();
            #endregion

            #region DI Transient
            services.AddHttpClient<TmdbClient>();
            #endregion

            #region DI Scoped
            services.AddScoped<ITmdbSync, TmdbSync>();
            services.AddScoped<ITrendingMoviesService, TrendingMoviesService>();
            services.AddScoped<IMovieDetailsService, MovieDetailsService>();
            services.AddScoped<IMovieCreditsService, MovieCreditsService>();
            services.AddScoped<ITmdbService, TmdbService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFilter, Filter>();
            #endregion

            #region DI Singeltons
            services.AddSingleton(mapper);
            #endregion

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
