using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Net.Http;

namespace DesktopApp.Services
{
    public static class ApiClientService
    {
        private static IConfiguration _config;

        static ApiClientService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _config = builder.Build();
        }

        public static HttpClient CreateClient()
        {
            string baseUrl = _config["ApiSettings:BaseUrl"];
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            return client;
        }
    }
}
