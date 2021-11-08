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

        public static bool YearValidation(int year,int minimalYear)
        {
            if (year > minimalYear) return true;
            return false;
        }
    }
}
