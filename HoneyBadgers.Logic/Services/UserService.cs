using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Repositories.Interfaces;
using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;

namespace HoneyBadgers.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
