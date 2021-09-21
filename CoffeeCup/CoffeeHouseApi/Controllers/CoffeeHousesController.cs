using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CoffeeHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeHousesController : ControllerBase
    {
        private readonly ICoffeeHouseService _coffeeHouseService;

        public CoffeeHousesController(ICoffeeHouseService coffeeHouseService)
        {
            _coffeeHouseService = coffeeHouseService;
        }

        [HttpGet("GetPopularCoffeeHouses")]
        public async Task<IActionResult> GetPopularCoffeeHouses() =>  
            Ok(await _coffeeHouseService.GetPopularCoffeeHouses());

        [HttpGet]
        public async Task<IActionResult> Get() => 
            Ok(await _coffeeHouseService.GetAllAsync());

        [HttpPut]
        public async Task<IActionResult> Get([FromBody] GetCoffeeHousesByAdmin command) => 
            Ok(await _coffeeHouseService.GetAllAsync(command.AdminId));

        [HttpGet("GetCoffeeItemByUserAsync")]
        public async Task<IActionResult> GetCoffeeItemByUserAsync([FromQuery] string idUser) => 
            Ok(await _coffeeHouseService.GetCoffeeItemByUserAsync(idUser));

        [HttpGet("GetByCoffeeHousesIdUser")]
        public async Task<IActionResult> GetByCoffeeHousesIdUser([FromQuery] string userId) => 
            Ok(await _coffeeHouseService.GetByCoffeeHousesIdUser(userId));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => 
            Ok(await _coffeeHouseService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CoffeeHouse value) => 
            Ok(await _coffeeHouseService.AddAsync(value));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CoffeeHouse value) => 
            Ok(await _coffeeHouseService.UpdateAsync(value));

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}