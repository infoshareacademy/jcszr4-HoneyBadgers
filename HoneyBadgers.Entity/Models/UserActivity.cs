using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Entity.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ActionArguments { get; set; }
        public string UserName { get; set; }
        public string IpAddress { get; set; }
        public DateTime ActivityDate { get; set; }
    }
}
