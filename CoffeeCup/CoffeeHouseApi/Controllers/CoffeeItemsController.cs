using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeItemsController : ControllerBase
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        public CoffeeItemsController(ICoffeeHouseService coffeeHouseService)
        {
            _coffeeHouseService = coffeeHouseService;
        }
        // GET: api/<CoffeeItemsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CoffeeItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CoffeeItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        [HttpGet("sellCoffeeItem/{id}/{userId}")]
        public async Task<IActionResult> SellCoffeeItem(int id, string userId)
        {
            await _coffeeHouseService.SellCoffeeItemAsync(userId, id);
            return Ok();
        }

        // DELETE api/<CoffeeItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
