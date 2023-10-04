namespace CastleGuard.Bot
{
    internal class MarkdownParser
    {
        /// <summary>
        /// Constant chars array used in Markdown markup.
        /// </summary>
        private static readonly char[] _specialChars = new char[] { '_', '*', '[', ']', '(', ')', '~', '`', '>', '#',
                                                                    '+', '-', '+', '|', '{', '}', '.', '!' };

        /// <summary>
        /// Parses Markdown markup symbols in string to non-markup characters.
        /// </summary>
        /// <param name="text">String to parse.</param>
        /// <returns>Parsed string.</returns>
        public static string Parse(string text)
        {
            string parsedString = default!;

            var chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (_specialChars.Contains(chars[i]))
                {
                    parsedString += @$"\{chars[i]}";
                }
                else
                {
                    parsedString += chars[i];
                }
            }

            return parsedString;
        }
    }
}
