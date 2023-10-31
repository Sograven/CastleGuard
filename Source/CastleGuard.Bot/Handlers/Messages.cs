using Telegram.Bot;
using Telegram.Bot.Types;

namespace CastleGuard.Bot.Handlers
{
    internal class Messages
    {
        public static async Task HandleMessagesAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            if (message.Text != null && message.Text.StartsWith('/'))
            {
                await Commands.HandleCommandsAsync(botClient, message, cancellationToken);
            }
        }
    }
}
