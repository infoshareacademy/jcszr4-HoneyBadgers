using System;
using System.Collections.Generic;

namespace HoneyBadgers.WebApp.Models
{
    public class ChartViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Tuple<string, int>> ChartData { get; set; }
    }
}
