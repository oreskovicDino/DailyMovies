namespace DailyMoviesBLL.Helper
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// HTTP Client Type for the TMDB site
    /// </summary>
    public class TmdbClient
    {
        private readonly HttpClient client;

        private readonly IOptions<AppOptions> options;

        public TmdbClient(HttpClient client, IOptions<AppOptions> options)
        {
            this.client = client;
            this.options = options;
            InitClient();
        }

        /// <summary>
        /// Method builds HTTP GET request to the TMDB site.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns><typeparamref name="Task"/> of type <typeparamref name="T"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetRequestAsync<T>(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }



            using (HttpResponseMessage response = await client.GetAsync(AddressResolver(path)))
            {
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// HTTP Client Initialization method.
        /// 
        /// Sets client base address.
        /// Clears accept header.
        /// Sets accept header to "application/json".
        /// </summary>
        private void InitClient()
        {
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
        }

        /// <summary>
        /// Method retrieves TMDB API key and concatenates to the <paramref name="path"/> value.
        /// </summary>
        /// <param name="path">Resolved TMDB URL address</param>
        /// <returns></returns>
        private string AddressResolver(string path)
        {
            return path += $"api_key={options.Value.TmdbApiKey}";
        }
    }
}
