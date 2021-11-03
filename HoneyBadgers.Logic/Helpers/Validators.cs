using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Helpers
{
    public static class Validators
    {
        public static bool StringValidator(string input, int minLength, int maxLength)
        {
            if (input == null)
            {
                return false;
            }
            var result = input.Trim();
            return result.Length >= minLength && result.Length <= maxLength;
        }
    }
}
