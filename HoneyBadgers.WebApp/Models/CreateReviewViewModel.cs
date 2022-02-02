using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.WebApp.Models
{
    public class CreateReviewViewModel
    {
        public string Title { get; set; }
        [AllowHtml]
        [Display(Name = "Review")]
        public string Review { get; set; }
        public Movie Movie { get; set; }
    }
}