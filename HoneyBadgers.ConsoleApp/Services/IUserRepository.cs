using System.Collections.Generic;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp.Services
{
    public interface IUserRepository
    {
        List<User> Users { get; }
        void AddUser();
        User GetUserData();
    }
}