namespace CastleGuard.Bot
{
    internal static class Constants
    {
        /// <summary>
        /// Default name of environment variable for config.
        /// </summary>
        public static readonly string DefaultConfigVariableName = "CastleGuardBot";
        /// <summary>
        /// Default value of environment variable for config.
        /// </summary>
        public static readonly string DefaultConfigVariableValue = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CastleGuard\Bot";
    }
}
