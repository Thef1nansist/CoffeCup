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
        Task<bool> CreateAsync(string userName, string password, bool checkbox);

        public bool GetFlag();

        Task<IEnumerable<AppUser>> GetAsync();
        Task<(bool, bool)> LoginAsync(string text, string password);
    }
}