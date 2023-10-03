using System.Text.Json;

namespace CastleGuard.Bot
{
    internal class BotData
    {
        private static readonly JsonSerializerOptions _options = new() { IncludeFields = true, WriteIndented = true };
        private class Fields
        {
            public string Token = default!;
            public string Name = default!;
            public string? Description = default!;
            public string? ShortDescription = default!;
        }


        public static string Token { get => GetConfig().Token; }
        public static string Name { get => GetConfig().Name; }
        public static string? Description { get => GetConfig().Description; }
        public static string? ShortDescription { get => GetConfig().ShortDescription; }


        /// <summary>
        /// Deserializes config file to <see cref="Fields"/> or calls <see cref="CreateConfig"/> if config doesn't exist.
        /// </summary>
        /// <returns>Config deserialized to <see cref="Fields">Fields</see></returns>
        private static Fields GetConfig()
        {
            string path = Environment.GetEnvironmentVariable(Constants.DefaultConfigVariableName) ?? CreateConfig();

            var file = File.ReadAllText(path);
            var fields = JsonSerializer.Deserialize<Fields>(file, _options);

            return fields!;
        }

        /// <summary>
        /// Creates a config file and environment variable.
        /// </summary>
        /// <returns>Path to config file.</returns>
        private static string CreateConfig()
        {
            string name = Constants.DefaultConfigVariableName;
            string path = Constants.DefaultConfigVariableValue;
            if (Environment.GetEnvironmentVariable(name) is null) Environment.SetEnvironmentVariable(name, path); 

            if (Directory.Exists(path) is false) Directory.CreateDirectory(path);

            path += @"\Config.json";
            if (File.Exists(path) is false) File.WriteAllText(path, JsonSerializer.Serialize(new Fields(), _options));

            return path;
        }
    }
}
