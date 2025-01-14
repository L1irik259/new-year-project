using TaskManagementSystem.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TaskManagementSystem.Models.TelegBot.CreatMyTask;

public class TimeWhenRemindHandler : IHandler
{
    private IHandler? _nextHandler;

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }

    [Obsolete]
    public async Task HandleAsync(ITelegramBotClient botClient, Message message, Dictionary<long, string> userStates, List<string> listForMyTask)
        {
            if (userStates.TryGetValue(message.Chat.Id, out var state) && state == "ask_time_when_remind")
            {
                await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"Спасибо за информацию!");
                if (message.Text is not null)
                    listForMyTask.Add(message.Text);
                userStates.Remove(message.Chat.Id); // Завершаем диалог
            }
            else if (_nextHandler != null)
            {
                await _nextHandler.HandleAsync(botClient, message, userStates, listForMyTask);
            }
        }
}   