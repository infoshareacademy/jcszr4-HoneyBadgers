using System.Collections.Generic;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.WebApp.Models
{
    public class ReviewListModel
    {
        public Movie Movie { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
