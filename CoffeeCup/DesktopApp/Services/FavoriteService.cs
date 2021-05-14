using DesktopApp.Interfaces;
using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesktopApp.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAppUserService _appUserService;

        public FavoriteService(IHttpClientFactory httpClientFactory, IAppUserService appUserService)
        {
            _httpClientFactory = httpClientFactory;
            _appUserService = appUserService;
        }
        public async Task<bool> CreateFavoriteCoffeeHouse(AddFavoriteCoffeeHouse addModel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/favorites");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var item = JsonSerializer.Serialize(addModel);

            request.Content = new StringContent(item, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var res = await JsonSerializer.DeserializeAsync<int>(responseStream);

            return res > 0;
        }

        public async Task<IEnumerable<FavoriteCoffeeHouse>> GetFavoriteCoffeeHouses()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/favorites?userId={_appUserService.UserId}");

            using var client =
                
                
                
                
                _httpClientFactory.CreateClient("CoffeeHouseApi");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _appUserService.JWT);

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<FavoriteCoffeeHouse>>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return res;
        }
    }
}
