using Telegram.Bot;
using Telegram.Bot.Types;

namespace CastleGuard.Bot.Handlers
{
    internal class Messages
    {
        public static async Task HandleMessagesAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            if (message.Text is not null)
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: message.Text,
                    cancellationToken: cancellationToken
                    );
            }
        }
    }
}
