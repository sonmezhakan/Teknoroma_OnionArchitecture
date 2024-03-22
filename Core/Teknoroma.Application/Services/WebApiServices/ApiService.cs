using Microsoft.Extensions.Configuration;

namespace Teknoroma.Application.Services.WebApiServices
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["ApiServiceSettings:BaseAddress"]);
        }

        public HttpClient HttpClient => _httpClient;
    }
}
