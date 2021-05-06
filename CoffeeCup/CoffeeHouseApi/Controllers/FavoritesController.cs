using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        // GET: api/<FavoritesController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery]string userId)
        {
            var result = await _favoriteService
                .GetAll(userId)
                .ConfigureAwait(false);
            return Ok(result);
        }

        // GET api/<FavoritesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _favoriteService
                 .GetByIdAsync(id)
                 .ConfigureAwait(false);
            return Ok(result);
        }

        // POST api/<FavoritesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Favorite value)
        {
            var result = await _favoriteService
                .AddAsync(value)
                .ConfigureAwait(false);
            return CreatedAtAction(nameof(Post), result.Id);
        }

        // PUT api/<FavoritesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Favorite value)
        {
            var result = await _favoriteService
                .UpdateAsync(value)
                .ConfigureAwait(false);
            return Ok(result);
        }

        // DELETE api/<FavoritesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
