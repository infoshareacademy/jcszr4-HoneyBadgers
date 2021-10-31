using System.Collections.Generic;
using HoneyBadgers.Logic;

namespace HoneyBadgers
{
    public interface IUserRepository
    {
        List<User> Users { get; }
        void AddUser();
        User GetUserData();
    }
}