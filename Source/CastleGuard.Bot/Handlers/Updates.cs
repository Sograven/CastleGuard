using Telegram.Bot;
using Telegram.Bot.Types;

namespace CastleGuard.Bot.Handlers
{
    internal class Updates
    {
        public static async Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is null)
                return;

            await Messages.HandleMessagesAsync(botClient, update.Message, cancellationToken);
        }
    }
}
