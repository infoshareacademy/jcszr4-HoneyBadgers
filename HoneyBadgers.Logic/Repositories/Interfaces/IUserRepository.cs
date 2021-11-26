using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories
{
    public interface IUserRepository
    {
        static List<User> Users { get; }
        List<User> GetAll();
        void AddUser(User user);
        void EditUser(User user);
    }
}