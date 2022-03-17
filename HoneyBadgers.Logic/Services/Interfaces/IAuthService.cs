using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IAuthService
    {
        string GetUserId();
        Task<ApplicationUser> GetUser();
    }
}