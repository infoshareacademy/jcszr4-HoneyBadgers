using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyBadgers.WebApp.Models
{
    public class CreateReviewResultModel
    {
        public string Title { get; set; }
        public string Review { get; set; }
        public string MovieId { get; set; }
    }
}
