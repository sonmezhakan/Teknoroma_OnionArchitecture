using Microsoft.Extensions.Configuration;

namespace Teknoroma.Infrastructure.WebApiService
{
    public class ApiService:IApiService
    {
        private readonly HttpClient _httpClient;

		public ApiService(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["WebApiConfiguration:BaseAddress"]);
		}

        public HttpClient HttpClient => _httpClient;
    }
}
