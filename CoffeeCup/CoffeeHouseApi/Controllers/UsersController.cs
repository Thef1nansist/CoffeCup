using BusinessLogic.Interfaces;
using BusinessLogic.Models;
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
    public class UsersController : ControllerBase
    {
        private readonly IAppUserService _userService;
        public UsersController(IAppUserService appUserService)
        {
            _userService = appUserService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService
                .Get()
                .ConfigureAwait(false);

            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _userService
                .FindByIdAsync(id)
                .ConfigureAwait(false);

            return Ok(result);
        }

        // POST api/<UsersController>
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
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
