using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Movie> Movies { get; set; }

        public Dictionary<string, string> UserMovieStatus = new Dictionary<string, string>();
    }
}
