using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeHouseApi.Controllers
{
    // matanit routing web api
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
        public async Task<IActionResult> GetPopularCoffeeHouses()
        {
            var result = await _coffeeHouseService
                .GetPopularCoffeeHouses()
                .ConfigureAwait(false);
            return Ok(result);
        }



        // GET: api/<CoffeeHousesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _coffeeHouseService
                .GetAllAsync()
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Get([FromBody] GetCoffeeHousesByAdmin command)
        {
            var result = await _coffeeHouseService
                .GetAllAsync(command.AdminId)
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("GetCoffeeItemByUserAsync")]
        public async Task<IActionResult> GetCoffeeItemByUserAsync([FromQuery] string idUser)
        {
            var rezult = await _coffeeHouseService
                .GetCoffeeItemByUserAsync(idUser)
                .ConfigureAwait(false);
            return Ok(rezult);
        }

        // GET api/<CoffeeHousesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _coffeeHouseService
                .GetByIdAsync(id)
                .ConfigureAwait(false);
            return Ok(result);
        }

        // POST api/<CoffeeHousesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CoffeeHouse value)
        {
            var result = await _coffeeHouseService
                .AddAsync(value)
                .ConfigureAwait(false);
            return CreatedAtAction(nameof(Post), result);
        }

        // PUT api/<CoffeeHousesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CoffeeHouse value)
        {
            var result = await _coffeeHouseService
                .UpdateAsync(value)
                .ConfigureAwait(false);
            return Ok(result);
        }

        // DELETE api/<CoffeeHousesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}