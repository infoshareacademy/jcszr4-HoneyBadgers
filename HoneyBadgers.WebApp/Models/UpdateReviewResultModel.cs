using System.ComponentModel.DataAnnotations;

namespace HoneyBadgers.WebApp.Models
{
    public class UpdateReviewResultModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Review { get; set; }
        [Required]
        public string MovieId { get; set; }
    }
}
