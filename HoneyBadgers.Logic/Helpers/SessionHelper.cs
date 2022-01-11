using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using Microsoft.AspNetCore.Http;

namespace HoneyBadgers.Logic.Helpers
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetUserSession(User user)
        {
            _httpContextAccessor.HttpContext.Session.SetString("FullName", user.FirstName + " " + user.LastName);
            _httpContextAccessor.HttpContext.Session.SetString("Email", user.Email);
            _httpContextAccessor.HttpContext.Session.SetString("UserId", user.Id.ToString());
        }

        public void ClearUserSession()
        {
            _httpContextAccessor.HttpContext.Session.Remove("FullName");
            _httpContextAccessor.HttpContext.Session.Remove("Email");
            _httpContextAccessor.HttpContext.Session.Remove("UserId");
        }
    }
}
