using System.Collections.Generic;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.WebApp.Models
{
    public class ReviewListModel
    {
        public DetailMovieViewModel Movie { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
