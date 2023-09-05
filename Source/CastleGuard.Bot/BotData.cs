using System.Text.Json;

namespace CastleGuard.Bot
{
    internal class BotData
    {
        private class Fields
        {
            public string Token = default!;
            public string Name = default!;
            public string? Description = default!;
            public string? ShortDescription = default!;
        }

        private static string _filePath = Environment.GetEnvironmentVariable("CastleGuardBot")!;
        private static string _file = File.ReadAllText(_filePath);

        private static readonly JsonSerializerOptions _options = new() { IncludeFields = true, WriteIndented = true };
        private static Fields _fields = JsonSerializer.Deserialize<Fields>(_file, _options)!;

        public static string Token { get => _fields.Token; }
        public static string Name { get => _fields.Name; }
        public static string? Description { get => _fields.Description; }
        public static string? ShortDescription { get => _fields.ShortDescription; }
    }
}
