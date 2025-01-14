using TaskManagementSystem.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TaskManagementSystem.Models.TelegBot.CreatMyTask;

public class StartHandler : IHandler
{
    private IHandler? _nextHandler;

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }

    [Obsolete]
    public async Task HandleAsync(ITelegramBotClient botClient, Message message, Dictionary<long, string> userStates, List<string> listForMyTask)
        {
            if (message.Text != null && message.Text.ToLower() == "/start")
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Добро пожаловать! Как назовете задачу?");
                userStates[message.Chat.Id] = "ask_name"; // Переход к следующему шагу
            }
            else if (_nextHandler != null)
            {
                await _nextHandler.HandleAsync(botClient, message, userStates, listForMyTask);
            }
        }
}