using CastleGuard.Bot.Generation;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CastleGuard.Bot.Handlers
{
    internal class Commands
    {
        public static async Task HandleCommandsAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var command = message.Text!.Trim();
            var answer = command switch
            {
                "/about" => About(),
                "/generate" => Generate(),
                "/help" => Help(),
                "/start" => Start(),
                _ => "Unknown command."
            };

            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: answer,
                parseMode: ParseMode.MarkdownV2,
                cancellationToken: cancellationToken
                );
        }

        private static string About()
        {
            return "About";
        }
        private static string Generate()
        {
            string password = Generator.Generate();
            string answer = "The new generated password is here\\. \n" +
                            "Store it in secure place and don't use it more than once\\.\n\n" +
                            $"Password: `{MarkdownParser.Parse(password)}`";
            return answer;
        }
        private static string Help()
        {
            return "Help";
        }

        private static string Start()
        {
            return "Start";
        }
    }
}
