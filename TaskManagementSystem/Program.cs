using System;
using TaskManagementSystem.Models;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Task = TaskManagementSystem.Models.MyTask;

namespace TaskManagementSystem
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main()
        {   
            DateBase dateBase = DateBase.GetInstance();
            // Создаем дату
            DateTime specificDate = new DateTime(2015, 7, 20, 18, 30, 25);

            // Создаем задачу с помощью TaskBuilder
            MyTask task = new TaskBuilder()
                .WithId()
                .WithTaskStatus(1)
                .WithTime(specificDate)
                .WithName("Math")
                .WithComment("sdf")
                .WithTimeWhenRemind(specificDate)
                .GetResult();

            // Выводим имя задачи
            Console.WriteLine($"Task Name: {task.Name}, {task.Time}");

            dateBase.AddTask(task);

            // var bot = new TelegramBotClient("7937143525:AAGvcB94t_SsRLrU2B_ToTtTxZaqLfhYMsQ");
            // var me = await bot.GetMe();
            // Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");            
        }
    }
}
