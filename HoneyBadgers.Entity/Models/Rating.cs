namespace HoneyBadgers.Entity.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }

        public Rating(string source, string value)
        {
            Source = source;
            Value = value;
        }
    }
}