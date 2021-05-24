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
    public class CoffeeHouseService : ICoffeeHouseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAppUserService _appUserService;

        public CoffeeHouseService(IHttpClientFactory httpClientFactory, IAppUserService appUserService)
        {
            _httpClientFactory = httpClientFactory;
            _appUserService = appUserService;
        }
        public async Task<CoffeeHouse> AddAsync(CoffeeHouse coffeeHouse)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/coffeehouses");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var item = JsonSerializer.Serialize(coffeeHouse);

            request.Content = new StringContent(item, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var res = await JsonSerializer.DeserializeAsync<CoffeeHouse>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

            });

            return res;
        }

        public async Task<IEnumerable<CoffeeHouse>> GetAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/coffeehouses");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<CoffeeHouse>>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return res;
        }
        public async Task<IEnumerable<CoffeeHouse>> GetAsync(string adminId)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "/api/coffeehouses");
            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");
            var item = JsonSerializer.Serialize(new GetCoffeeHouseByAdmin { AdminId = adminId });
            request.Content = new StringContent(item, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<CoffeeHouse>>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return res;
        }

        public async Task<List<CoffeeItem>> GetCoffeeItemByUserAsync(string userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/coffeehouses/GetCoffeeItemByUserAsync?idUser={userId}");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var res = await JsonSerializer.DeserializeAsync<List<CoffeeItem>>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return res;
        }

        public async Task<List<CoffeeHouse>> GetByCoffeeHousesIdUser()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/coffeehouses/GetByCoffeeHousesIdUser?userId={_appUserService.UserId}");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var res = await JsonSerializer.DeserializeAsync<List<CoffeeHouse>>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return res;
        }

        public async Task<IEnumerable<CoffeeHouse>> GetPopularCoffeeHouses()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/coffeehouses/GetPopularCoffeeHouses");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var res = await JsonSerializer.DeserializeAsync<IEnumerable<CoffeeHouse>>(
                responseStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return res;
        }

        public async Task SellCoffeeItemAsync(string userId, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/coffeeitems/sellCoffeeItem/{id}/{userId}");

            using var client = _httpClientFactory.CreateClient("CoffeeHouseApi");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _appUserService.JWT);

            await client.SendAsync(request);

        }

    }
}
