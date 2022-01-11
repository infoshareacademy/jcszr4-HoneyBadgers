﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace HoneyBadgers.Logic.Services
{
    public class AuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IRepository<User> userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResult> Login(string email, string password)
        {
            var salt = System.Text.Encoding.UTF8.GetBytes("my salt");
            var bytePassword = System.Text.Encoding.UTF8.GetBytes(password);
            var hmacMd5 = new HMACMD5(salt);
            var saltedHash = hmacMd5.ComputeHash(bytePassword);
            var data = _userRepository.GetAllQueryable()
                .Where(s => s.Email.Equals(email) && s.Password.Equals(Convert.ToBase64String(saltedHash)))
                .ToList();
            // var data = _userRepository.GetAllQueryable().Where(s => s.Email.Equals(email)).ToList();
            var user = data.FirstOrDefault();
            if (user != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("FullName", user.FirstName + " " + user.LastName);
                _httpContextAccessor.HttpContext.Session.SetString("Email", user.Email);
                _httpContextAccessor.HttpContext.Session.SetString("UserId", user.Id.ToString());
                // _httpContextAccessor.HttpContext.Session.SetString();
                // var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                // claimsIdentity.AddClaim(new Claim("name", "aaaa"));
                // await _httpContextAccessor.HttpContext.SignInAsync(
                //     CookieAuthenticationDefaults.AuthenticationScheme,
                //     new ClaimsPrincipal(claimsIdentity)
                // );

                // var claims = new List<Claim>
                // {
                //     new Claim(ClaimTypes.Name, user.FirstName)
                // };
                //
                // var userIdentity = new ClaimsIdentity(claims, "login");
                // // var userIdentity = new List<ClaimsIdentity>( subject)
                // // {
                // //     DisplayName = name,
                // //     AdditionalClaims = claims,
                // //     AuthenticationTime = clock.UtcNow.UtcDateTime
                // // };
                //
                // ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                // _httpContextAccessor.HttpContext.SignInAsync(principal);
                // user.Password = Convert.ToBase64String(saltedHash);
                // _userRepository.Update(user);
                // _userRepository.Insert(new User()
                // {
                //     FirstName = "Admin",
                //     LastName = "Admin",
                //     Email = "admin@admin.test",
                //     Password = Convert.ToBase64String(saltedHash)
                // });
            }
            // var cos = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            if (user != null)
            {
                return new LoginResult()
                {
                    UserId = user.Id,
                    UserName = user.FirstName + " " + user.LastName,
                    UserEmail = user.Email
                };
            }
            return null;
        }
    }
}