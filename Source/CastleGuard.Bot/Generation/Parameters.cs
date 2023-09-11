namespace CastleGuard.Bot.Generation
{
    internal class Parameters
    {
        private readonly List<char> _numbers = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private readonly List<char> _symbols = new() { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*',
                                                       '(', ')', '-', '_', '=', '+', '[', '{', ']', '}',
                                                       '\\', '|', ';', ':', '\'', '"', ',', '<', '.', '>',
                                                       '/', '?' };
        private readonly List<char> _lowercase = new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                                         'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                                         'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly List<char> _uppercase = new() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                                         'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                                         'U', 'V', 'W', 'X', 'Y', 'Z' };

        public int Length { get; set; }
        public bool IsRepeating { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSymbols { get; set; }
        public bool IncludeLowercase { get; set; }
        public bool IncludeUppercase { get; set; }

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
