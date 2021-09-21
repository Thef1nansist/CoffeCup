using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoffeeHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAppUserService _userService;
        public UsersController(IAppUserService appUserService)
        {
            _userService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _userService.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) => 
            Ok(await _userService.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppUser user)
        {
            if (user == null) return BadRequest();
            try
            {
                var result = await _userService.CreateAsync(user, user?.Password).ConfigureAwait(false);
                
                if (result != null) return Ok(true);

                return BadRequest();
            }
            //result.Errors.FirstOrDefault().Description
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUser user)
        {
            try
            {
                var loginUser = await _userService.LoginAsync(user, user?.Password).ConfigureAwait(false);
                return CreatedAtAction(nameof(Login), new { access_token = loginUser.Item1, userId = loginUser.Item2, isAdmin = loginUser.Item3 });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
