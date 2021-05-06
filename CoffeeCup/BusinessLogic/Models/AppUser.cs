using AutoMapper;
using Microsoft.AspNetCore.Identity;
using DA = Infrastructure.Models;

namespace BusinessLogic.Models
{
    public class AppUser : IdentityUser
    {
        public string Password { get; set; }

        public static void CreateMaps(Profile profile)
        {
            profile.CreateMap<DA.AppUser, AppUser>()
                 .ForMember(appUser => appUser.Id, optional => optional.Condition(user => user.Id != null))
                 .ReverseMap();
        }
    }
    
}
