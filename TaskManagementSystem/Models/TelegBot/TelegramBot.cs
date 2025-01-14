using Telegram.Bot;

namespace TaskManagementSystem.Models.TelegBot;

public class TelegramBot
{
    private static ITelegramBotClient? botClient = null;

    private TelegramBot()
    {
        botClient = new TelegramBotClient("7937143525:AAGvcB94t_SsRLrU2B_ToTtTxZaqLfhYMsQ");
    }

    public TelegramBotClient? GetBotClient()
    {
        if (botClient is not null)
        {
            return (TelegramBotClient)botClient;
        }
        
        return null;
    }

    public static TelegramBot GetInstance()
    {
        if (botClient is null)
        {
            TelegramBot newBot = new TelegramBot();
            return newBot;
        } 
        else
        {
            throw new ArgumentException("You have been created TelegramBot.");
        }
    }
}