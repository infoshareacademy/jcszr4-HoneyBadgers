using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HoneyBadgers.Logic.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return userId;
        }

        public async Task<ApplicationUser> GetUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return user;
        }
    }
}
