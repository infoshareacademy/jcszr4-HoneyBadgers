namespace HoneyBadgers.Logic
{
    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }

        public Rating(string source, string value)
        {
            Source = source;
            Value = value;
        }
    }
}