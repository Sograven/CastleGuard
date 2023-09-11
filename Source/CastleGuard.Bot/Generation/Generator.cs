namespace CastleGuard.Bot.Generation
{
    internal static class Generator
    {
        public static string Generate()
        {
            string password = default!;

            var parameters = new Parameters();
            List<char> source = parameters.GetCharSource();

            var random = new Random();
            for (int i = 0; i < parameters.Length; i++)
            {
                int charIndex = random.Next(0, source.Count - 1);
                password = string.Concat(password, source[charIndex]);

                if (parameters.IsRepeating!) source.RemoveAt(charIndex);
            }

            return password;
        }
    }
}
