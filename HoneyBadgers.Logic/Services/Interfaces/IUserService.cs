using HoneyBadgers.Logic.Models;
using System.Collections.Generic;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
    }
}
