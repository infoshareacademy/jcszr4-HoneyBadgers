using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users { get; private set; } = new List<User>();

        public UserRepository()
        {
            Users.AddRange(FileDataReader.LoadUsers());
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void EditUser(User user)
        {
            var index = Users.FindIndex(u => u.Id == user.Id);
            Users[index] = user;
        }
    }
}
