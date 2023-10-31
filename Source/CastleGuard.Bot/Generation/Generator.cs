namespace CastleGuard.Bot.Generation
{
    internal static class Generator
    {
        /// <summary>
        /// Generates a password with default <see cref="Parameters"/>.
        /// </summary>
        /// <returns> Password as <see langword="string"/>. </returns>
        public static string Generate()
        {
            string password = default!;

            var parameters = new Parameters();
            List<char> source = parameters.GetCharSource();

            var random = new Random();
            for (int i = 0; i < parameters.Length; i++)
            {
                int charIndex = random.Next(0, source.Count - 1);
                password += source[charIndex];

                if (parameters.IsRepeating!) source.RemoveAt(charIndex);
            }

            return password;
        }
    }
}