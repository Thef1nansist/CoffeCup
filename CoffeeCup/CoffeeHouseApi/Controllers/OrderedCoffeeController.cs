using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeHouseApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class OrderedCoffeeController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public OrderedCoffeeController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] string userId) => 
            Ok(await _favoriteService.GetOrderedCoffee(userId));
 
    }
}
