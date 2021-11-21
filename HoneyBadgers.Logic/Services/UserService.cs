using HoneyBadgers.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Services
{
    public class UserService
    {
        private UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public List<User> GetAll()
        {
            return UserRepository.Users;
        }
    }
}
