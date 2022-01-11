using System;
using System.Linq;
using System.Security.Cryptography;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Helpers;

namespace HoneyBadgers.Logic.Services
{
    public class AuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly SessionHelper _sessionHelper;
        public AuthService(IRepository<User> userRepository, SessionHelper sessionHelper)
        {
            _userRepository = userRepository;
            _sessionHelper = sessionHelper;
        }

        public bool Login(string email, string password)
        {
            var hashPassword = GetHashPassword(password);
            var data = _userRepository.GetAllQueryable()
                .Where(s => s.Email.Equals(email) && s.Password.Equals(hashPassword))
                .ToList();
            var user = data.FirstOrDefault();
            if (user != null)
            {
                _sessionHelper.SetUserSession(user);
                return true;
            }

            return false;
        }

        public void Logout()
        {
            _sessionHelper.ClearUserSession();
        }

        private string GetHashPassword(string password)
        {
            var salt = System.Text.Encoding.UTF8.GetBytes("becia salt");
            var bytePassword = System.Text.Encoding.UTF8.GetBytes(password);
            var hmacMd5 = new HMACMD5(salt);
            var saltedHash = hmacMd5.ComputeHash(bytePassword);
            return Convert.ToBase64String(saltedHash);
        }
    }
}
