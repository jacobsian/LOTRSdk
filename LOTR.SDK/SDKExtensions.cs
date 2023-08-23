using LOTR.SDK.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace LOTR.SDK
{
    public static class SDKExtensions
    {
        /// <summary>
        /// Adds the LOTR API SDK to the container so it's available through dependency injection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="apiKey">API key used to auth to the services</param>
        /// <returns></returns>
        public static IServiceCollection AddLOTR(this IServiceCollection services, string apiKey)
        {

            services.AddHttpClient<MovieService>( client =>
                {
                    client.BaseAddress = new Uri("https://the-one-api.dev/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                }
            );

            services.AddHttpClient<QuoteService>(client =>
            {
                client.BaseAddress = new Uri("https://the-one-api.dev/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            });

            return services;
        }
    }
}
