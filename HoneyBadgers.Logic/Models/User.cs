using System.Collections.Generic;

namespace HoneyBadgers.Logic.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
