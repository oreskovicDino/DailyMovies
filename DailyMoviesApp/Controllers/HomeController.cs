namespace DailyMoviesApp.Controllers
{
    using DailyMoviesApp.Models;
    using DailyMoviesBLL.Helper;
    using DailyMoviesBLL.Models;
    using DailyMoviesBLL.Services;
    using DailyMoviesBLL.Services.Abstractions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITmdbService tmdbService;
        private readonly ITrendingMoviesService trendingMovies;

        public HomeController(ILogger<HomeController> logger, ITmdbService tmdbService, ITrendingMoviesService trendingMovies)
        {
            _logger = logger;
            this.tmdbService = tmdbService;
            this.trendingMovies = trendingMovies;
        }

        public async Task<IActionResult> Index()
        {
            Filter filter = new Filter
            {
                FilterString = ""
            };
            await tmdbService.SyncMovies(filter);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
