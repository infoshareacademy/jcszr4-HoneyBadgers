namespace HoneyBadgers.Logic.Dto
{
    public class MovieDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public double ImdbRating { get; set; }
        public string Poster { get; set; }
        public int ViewsNumber { get; set; }
        public bool IsFavorite { get; set; }
    }
}
