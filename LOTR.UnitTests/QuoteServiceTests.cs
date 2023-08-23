using Moq.Protected;
using Moq;
using System.Net;
using LOTR.SDK.Services;
using Microsoft.Extensions.Logging;

namespace LOTR.UnitTests
{
    public class QuoteServiceTests
    {
        [Fact]
        public async Task GetQuoteAsync_AppendsFilterExpression()
        {
            var filterExpression = "budgetInMillions<100";
            void messageValidator(HttpRequestMessage m)
            {
                Assert.EndsWith(filterExpression, m.RequestUri.ToString());
            }

            var mockHandler = prepareMockHandler("{}", messageValidator);
            var mockLogger = new Mock<ILogger<QuoteService>>();
            var fakeClient = new HttpClient(mockHandler.Object)
            {
                BaseAddress = new Uri("http://localhost:12345/")
            };        

            var service = new QuoteService(fakeClient, mockLogger.Object);

            var results = await service.GetQuoteAsync("", filterExpression);
        }

        [Fact]
        public async Task GetMovieQuotes_AppendsFilterExpression()
        {
            var filterExpression = "budgetInMillions<100";
            void messageValidator(HttpRequestMessage m)
            {
                Assert.EndsWith(filterExpression, m.RequestUri.ToString());
            }

            var mockHandler = prepareMockHandler("{}", messageValidator);
            var mockLogger = new Mock<ILogger<QuoteService>>();
            var fakeClient = new HttpClient(mockHandler.Object)
            {
                BaseAddress = new Uri("http://localhost:12345/")
            };

            var service = new QuoteService(fakeClient, mockLogger.Object);

            var results = await service.GetMovieQuotes("54321", filterExpression);
        }

        private Mock<HttpMessageHandler> prepareMockHandler(string? mockedResponse = null, Action<HttpRequestMessage> messageValidator = null)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((message, _) =>
                {
                    if (messageValidator != null)
                        messageValidator(message);
                })
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(mockedResponse)
                });
            return mockMessageHandler;
        }
    }
}