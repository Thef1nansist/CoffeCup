using DesktopApp.Interfaces;
using DesktopApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DesktopApp.Extensions;
using System.Net.Http.Headers;

namespace DesktopApp.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public string JWT { get; set; }
        public string UserId { get; set; }

        public AppUserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateAsync(string userName, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");

            var user = JsonSerializer.Serialize(new AppUser() { UserName = userName, Password = password });

            request.Content = new StringContent(user, Encoding.UTF8, "application/json");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.SendAsync(request);

           
        }

        public async Task<IEnumerable<AppUser>> GetAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/users");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<AppUser>>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return res;           
        }

        public async Task<bool> LoginAsync(string text, string password)
        {
            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.PostAsJsonAsync("/api/users/login", new AppUser() { UserName = text, Password = password });
            
            var responseStream = await response.Content.ReadAsStringAsync();
            
            JWT = JsonSerializerExtensions
                .DeserializeAnonymousType(responseStream, new { access_token = "", userId = "" }).access_token;
            UserId = JsonSerializerExtensions
                .DeserializeAnonymousType(responseStream, new { access_token = "", userId = "" }).userId;
            return JWT != null;
        }

        public bool GetFlag()
        {
            return true;
            
        }
    }

}
