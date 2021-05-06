using DesktopApp.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesktopApp.Interfaces
{
    public interface IAppUserService
    {
        public string JWT { get; set; }
        public string UserId { get; set; }
        Task CreateAsync(string userName, string password);

        public bool GetFlag();

        Task<IEnumerable<AppUser>> GetAsync();
        Task<bool> LoginAsync(string text, string password);
    }
}