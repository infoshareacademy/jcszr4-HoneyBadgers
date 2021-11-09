using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories
{
    public interface IUserRepository
    {
        List<User> Users { get; }
        void AddUser(User user);
        void EditUser(User user);
    }
}