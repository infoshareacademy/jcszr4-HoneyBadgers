namespace HoneyBadgers.ConsoleApp.Helpers
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
