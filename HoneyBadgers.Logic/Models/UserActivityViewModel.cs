using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Models
{
    public class UserActivityViewModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string ActionArguments { get; set; }
        public string UserName { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
