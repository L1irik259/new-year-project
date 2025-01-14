using Telegram.Bot;
using Telegram.Bot.Types;

namespace TaskManagementSystem.Interfaces;

public interface IHandler
{
    Task HandleAsync(ITelegramBotClient botClient, Message message, Dictionary<long, string> userStates, List<string> listForMyTask);
}