using LOTR.SDK.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace LOTR.SDK.Services
{
    public sealed class MovieService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MovieService> _logger;

        public MovieService(HttpClient httpClient, ILogger<MovieService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Get movies from the system
        /// </summary>
        /// <param name="id">If supplied, specifies the id of the movie to return, else return all movies.</param>
        /// <param name="filterExpression">If supplied, filters the results down to what is specified.</param>
        /// <returns>A list of movies.</returns>
        public async Task<IList<Movie>> GetMovieAsync(string id = "", string filterExpression = "")
        {
            var path = string.IsNullOrEmpty(id) ? "v2/movie" : $"v2/movie/{id}";


            if (!String.IsNullOrEmpty(filterExpression))
            {
                path = String.Join("?", path, filterExpression);
            }

            var results = await _httpClient.GetFromJsonAsync<MovieList>(path);

            if (results == null || results.Docs == null)
            {
                return Enumerable.Empty<Movie>().ToList();
            }

            return results.Docs;
        }
    }
}
