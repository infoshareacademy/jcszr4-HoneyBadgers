namespace HoneyBadgers.RestApi.Models
{
    public class GenreStats : BaseEntity
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
