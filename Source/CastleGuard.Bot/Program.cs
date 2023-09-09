using CastleGuard.Bot;
using CastleGuard.Bot.Handlers;

using Telegram.Bot;
using Telegram.Bot.Polling;

var botClient = new TelegramBotClient(BotData.Token);

var receiverOptions = new ReceiverOptions();
var cts = new CancellationTokenSource();

botClient.StartReceiving(
    updateHandler: Updates.HandleUpdatesAsync,
    pollingErrorHandler: Errors.HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
    );

var me = await botClient.GetMeAsync();
Console.WriteLine($"Start listening for {me.FirstName}.");
Console.ReadLine();