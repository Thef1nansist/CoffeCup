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
        
        public bool IsAdmin { get; set; }

        public AppUserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateAsync(string userName, string password, bool checkbox)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");

            var user = JsonSerializer.Serialize(new AppUser() { UserName = userName, Password = password, IsAdmin = checkbox });

            request.Content = new StringContent(user, Encoding.UTF8, "application/json");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.SendAsync(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
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

        public async Task<(bool, bool)> LoginAsync(string text, string password)
        {
            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.PostAsJsonAsync("/api/users/login", new AppUser() { UserName = text, Password = password });
            
            var responseStream = await response.Content.ReadAsStringAsync();
            
            JWT = JsonSerializerExtensions
                .DeserializeAnonymousType(responseStream, new { access_token = "", userId = "", isAdmin = false }).access_token;
            UserId = JsonSerializerExtensions
                .DeserializeAnonymousType(responseStream, new { access_token = "", userId = "", isAdmin = false }).userId;
            IsAdmin = JsonSerializerExtensions
                .DeserializeAnonymousType(responseStream, new { access_token = "", userId = "", isAdmin = false }).isAdmin;

            return (JWT != null, IsAdmin);
        }

        public bool GetFlag() => true;
    }

}
