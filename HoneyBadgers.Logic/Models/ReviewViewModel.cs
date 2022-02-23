using System;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Logic.Models
{
    public class ReviewViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DetailMovieViewModel Movie { get; set; }
        public ApplicationUser User { get; set; }
    }
}
