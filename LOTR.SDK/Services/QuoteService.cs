using LOTR.SDK.Models;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net.Http.Json;

namespace LOTR.SDK.Services
{
    public sealed class QuoteService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<QuoteService> _logger;

        public QuoteService(HttpClient httpClient, ILogger<QuoteService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Get quotes from the system
        /// </summary>
        /// <param name="id">If supplied, specifies the id of the quote to return, else return all quotes.</param>
        /// <param name="filterExpression">If supplied, filters the results down to what is specified.</param>
        /// <returns>A list of quotes.</returns>
        public async Task<IList<Quote>> GetQuoteAsync(string id = "", string filterExpression = "")
        {
            var path = string.IsNullOrEmpty(id) ? "v2/quote" : $"v2/quote/{id}";

            if (!String.IsNullOrEmpty(filterExpression))
            {
                path = String.Join("?", path, filterExpression);
            }

            var results = await _httpClient.GetFromJsonAsync<QuoteList>(path);

            if (results == null)
            {
                return Enumerable.Empty<Quote>().ToList();
            }

            return results.Docs;
        }

        /// <summary>
        /// Returns all quotes from a specified movie.
        /// </summary>
        /// <param name="movieId">The ID of the movie</param>
        /// <param name="filterExpression">If supplied, filters the results down to what is specified.</param>
        /// <returns>A list of quotes that meet the criteria.</returns>
        public async Task<IList<Quote>> GetMovieQuotes(string movieId, string filterExpression = "")
        {
            var path = $"v2/movie/{movieId}/quote";

            if (!String.IsNullOrEmpty(filterExpression))
            {
                path = String.Join("?", path, filterExpression);
            }

            var results = await _httpClient.GetFromJsonAsync<QuoteList>(path);

            if (results == null)
            {
                return Enumerable.Empty<Quote>().ToList();
            }

            return results.Docs;
        }
    }
}
