using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HoneyBadgers.Entity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<FavoriteMovie> FavoriteMovies { get; set; }
        public virtual List<UserMovie> UserMovies { get; set; }
    }
}
