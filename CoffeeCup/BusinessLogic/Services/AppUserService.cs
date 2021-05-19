using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DA = Infrastructure.Models;

namespace BusinessLogic.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<DA.AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public static bool flag;

        public AppUserService(UserManager<DA.AppUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            var userDA = _mapper.Map<DA.AppUser>(user);

            return await _userManager
                .CheckPasswordAsync(userDA, password)
                .ConfigureAwait(false);
        }

        public async Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            var userDA = _mapper.Map<DA.AppUser>(user);
            var existUser = await _userManager.FindByNameAsync(user?.UserName).ConfigureAwait(false);
            IdentityResult result = null;

            if (existUser == null)
            {
                result = await _userManager.CreateAsync(userDA, password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimsAsync(userDA, new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, userDA?.UserName),
                    new Claim(JwtRegisteredClaimNames.Sub, userDA?.Id)
                }).ConfigureAwait(false);
                }

            }

            return result;
        }

        public bool GetFlag()
        {
            return flag;
        }

        public string CreateToken(IEnumerable<Claim> claims)
        {
            var secretsBytes = Encoding.UTF8.GetBytes(_configuration["TokenSecret"]);
            var key = new SymmetricSecurityKey(secretsBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                _configuration["TokenIssuer"],
                _configuration["TokenAudience"],
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(7),
                signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<AppUser> FindByIdAsync(string currentUserId)
        {

            var result = await _userManager.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == currentUserId)
                .ConfigureAwait(false);
            return _mapper.Map<AppUser>(result);
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            var result = await _userManager
                .FindByNameAsync(userName)
                .ConfigureAwait(false);
            return _mapper.Map<AppUser>(result);

        }
        public async Task<(string, string, bool)> LoginAsync(AppUser user, string password)
        {
            //find user
            var existUser = await _userManager.FindByNameAsync(user?.UserName).ConfigureAwait(false);

            //check pair user - password
            var checkUserPassword = await _userManager.CheckPasswordAsync(existUser, password).ConfigureAwait(false);
            if (existUser != null && checkUserPassword == true)
            {
                //generates user claims
                var claims = await _userManager.GetClaimsAsync(existUser).ConfigureAwait(false);
                //create JWT


                return (CreateToken(claims), existUser.Id, existUser.IsAdmin);
            }
            return (null, null, false);
        }
        public async Task<IEnumerable<AppUser>> Get()
        {
            var users = await _userManager.Users
                .AsNoTracking().ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<AppUser>>(users);
        }
    }
}
