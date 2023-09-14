using CastleGuard.Bot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace CastleGuard.Bot
{
    internal class CastleGuard
    {
        private static TelegramBotClient _botClient = new(BotData.Token);
        private static ReceiverOptions _receiverOptions = new();
        private static CancellationTokenSource _cts = new();

        public static async Task Main(string[] args)
        {
            StartListening();

            var bot = await _botClient.GetMeAsync();
            Console.WriteLine($"Start listening for {bot.FirstName}.");
            Console.WriteLine("Press «Shift + R» to reload client or «Shift + S» to stop listening.\n");

            do
            {
                var input = Console.ReadKey(true);
                switch (input.KeyChar)
                {
                    case 'R':
                        StopListening();
                        StartListening();

                        bot = await _botClient.GetMeAsync();
                        Console.WriteLine($"Client reloaded. Listening for {bot.FirstName}.\n");
                        break;

                    case 'S':
                        StopListening();

                        Console.WriteLine($"Stop listening for {bot.FirstName}.\n");
                        return;
                }
            } while (true);
        }

        static void StartListening()
        {
            _botClient.StartReceiving(
                updateHandler: Updates.HandleUpdatesAsync,
                pollingErrorHandler: Errors.HandlePollingErrorAsync,
                receiverOptions: _receiverOptions,
                cancellationToken: _cts.Token
                );
        }

        static void StopListening()
        {
            _cts.Cancel();

            _botClient = new TelegramBotClient(BotData.Token);
            _receiverOptions = new ReceiverOptions();
            _cts = new CancellationTokenSource();
        }
    }
}