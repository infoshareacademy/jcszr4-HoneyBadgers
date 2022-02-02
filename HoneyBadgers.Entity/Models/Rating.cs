namespace HoneyBadgers.Entity.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }
        public int Amount { get; set; }

        public Rating()
        {

        }
    }
}