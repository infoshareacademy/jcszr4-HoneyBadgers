using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoneyBadgers.Entity.Enums;

namespace HoneyBadgers.Entity.Models
{
    public class UserMovie
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        public string MovieId { get; set; }
        public MovieStatus Status { get; set; }
        public int Rate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
