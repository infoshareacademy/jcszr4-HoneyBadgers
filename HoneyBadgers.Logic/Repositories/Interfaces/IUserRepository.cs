using System.Collections.Generic;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Repositories.Interfaces
{
    public interface IUserRepository
    {
        static List<User> Users { get; }
        List<User> GetAll();
        void AddUser(User user);
        void EditUser(User user);
    }
}