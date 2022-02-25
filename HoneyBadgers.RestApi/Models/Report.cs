using System;

namespace HoneyBadgers.RestApi.Models
{
    public class Report: BaseEntity
    {
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
