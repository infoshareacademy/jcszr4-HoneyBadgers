using System;

namespace HoneyBadgers.Entity.Models
{
    public class Report
    {
        public Guid Id { get; private set; }
        public string Body { get; set; }

        public Report()
        {
            
        }

        public Report(string body)
        {
            Body = body;
        }
    }
}
