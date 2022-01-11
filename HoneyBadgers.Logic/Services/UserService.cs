using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;

namespace HoneyBadgers.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }
    }
}
