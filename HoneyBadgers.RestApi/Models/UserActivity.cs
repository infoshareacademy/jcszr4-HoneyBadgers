using System;

namespace HoneyBadgers.RestApi.Models
{
    public class UserActivity : BaseEntity
    {
        public string Url { get; set; }
        public string ActionArguments { get; set; }
        public string UserName { get; set; }
        public string IpAddress { get; set; }
    }
}
