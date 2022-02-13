using System;

namespace HoneyBadgers.Entity.Models
{
    public class Report
    {
        public Guid Id { get; private set; }
        public string Body { get; set; }

        public Report()
        {
            Id = Guid.NewGuid();
            Body = GenerateString();
        }

        private static string GenerateString()
        {
            var res = new Random();
            var allChars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var stringSize = 50;
            var randomString = "";

            for (var i = 0; i < stringSize; i++)
            {
                var x = res.Next(allChars.Length);
                randomString += allChars[x];
            }

            return randomString;

        }
    }
}
