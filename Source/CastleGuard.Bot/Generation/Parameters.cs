namespace CastleGuard.Bot.Generation
{
    internal class Parameters
    {
        /// <summary>
        /// List of numbers used in password generation.
        /// </summary>
        private readonly List<char> _numbers = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        /// <summary>
        /// List of symbols used in password generation.
        /// </summary>
        private readonly List<char> _symbols = new() { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*',
                                                       '(', ')', '-', '_', '=', '+', '[', '{', ']', '}',
                                                       '\\', '|', ';', ':', '\'', '"', ',', '<', '.', '>',
                                                       '/', '?' };
        /// <summary>
        /// List of lowercase letters used in password generation.
        /// </summary>
        private readonly List<char> _lowercase = new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                                         'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                                         'u', 'v', 'w', 'x', 'y', 'z' };
        /// <summary>
        /// List of uppercase letters used in password generation.
        /// </summary>
        private readonly List<char> _uppercase = new() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                                         'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                                         'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// Length of password.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Repeat symbol or use only once.
        /// </summary>
        public bool IsRepeating { get; set; }
        /// <summary>
        /// Use numbers or not.
        /// </summary>
        public bool IncludeNumbers { get; set; }
        /// <summary>
        /// Use symbols or not.
        /// </summary>
        public bool IncludeSymbols { get; set; }
        /// <summary>
        /// Use lowercase letters or not.
        /// </summary>
        public bool IncludeLowercase { get; set; }
        /// <summary>
        /// Use uppercase letters or not.
        /// </summary>
        public bool IncludeUppercase { get; set; }

        /// <summary>
        /// Generates array of characters used in password generation in accordance with set parameters.
        /// </summary>
        /// <returns></returns>
        public List<char> GetCharSource()
        {
            var source = new List<char>();

            if (IncludeNumbers) source.AddRange(_numbers);
            if (IncludeSymbols) source.AddRange(_symbols);
            if (IncludeLowercase) source.AddRange(_lowercase);
            if (IncludeUppercase) source.AddRange(_uppercase);

            // Catch «ArgumentOutOfRangeException» exception in generation.
            if (IsRepeating == false && Length < source.Count) Length = source.Count;

            return source;
        }

        /// <summary>
        /// Constructor with default parameters for password generation.
        /// </summary>
        public Parameters()
        {
            Length = 16;
            IsRepeating = true;
            IncludeNumbers = true;
            IncludeSymbols = true;
            IncludeLowercase = true;
            IncludeUppercase = true;
        }
    }
}
