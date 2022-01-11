using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyBadgers.Entity.Models
{
    public class FavoriteMovie
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int MovieId { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
