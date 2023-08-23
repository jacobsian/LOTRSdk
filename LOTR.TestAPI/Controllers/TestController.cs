using LOTR.SDK.Models;
using LOTR.SDK.Services;
using Microsoft.AspNetCore.Mvc;

namespace LOTR.TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly MovieService _movieService;
        private readonly QuoteService _quoteService;

        public TestController(ILogger<TestController> logger, MovieService movieService, QuoteService quoteService)
        {
            _logger = logger;
            _movieService = movieService;
            _quoteService = quoteService;
        }

        [HttpGet("GetMovies")]
        public Task<IList<Movie>> GetMovies(string movieId = "", string filterExpression = "")
        {
            return _movieService.GetMovieAsync(movieId, filterExpression);
        }

        [HttpGet("GetQuotes")]
        public Task<IList<Quote>> GetQuotes(string quoteId = "", string filterExpression = "")
        {
            return _quoteService.GetQuoteAsync(quoteId, filterExpression);
        }

        [HttpGet("GetMovieQuotes")]
        public Task<IList<Quote>> GetMovieQuotes(string movieId = "", string filterExpression = "")
        {
            return _quoteService.GetMovieQuotes(movieId, filterExpression);
        }
    }
}
