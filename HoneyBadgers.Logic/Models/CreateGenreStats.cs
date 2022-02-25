using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Models
{
    public class CreateGenreStats
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
    }
}
