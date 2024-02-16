using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Infrastructure.WebApiService
{
    public class ApiService:IApiService
    {
        private readonly HttpClient _httpClient;

		public ApiService(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["ApiServiceSettings:BaseAddress"]);
		}

        public HttpClient HttpClient => _httpClient;
    }
}
