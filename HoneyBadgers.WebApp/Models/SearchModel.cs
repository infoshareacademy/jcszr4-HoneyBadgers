using HoneyBadgers.WebApp.Enums;

namespace HoneyBadgers.WebApp.Models
{
    public class SearchModel
    {
        public string Query { get; set; }
        public FilterTypeEnum Type { get; set; }
    }
}
