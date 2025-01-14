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
            DateTime specificDate = new DateTime(2015, 7, 20, 18, 31, 25);

            // Создаем задачу с помощью TaskBuilder
            MyTask task = new TaskBuilder()
                .WithId()
                .WithTaskStatus(2)
                .WithTime(specificDate)
                .WithName("Matfsagh")
                .WithComment("sdf")
                .WithTimeWhenRemind(specificDate)
                .GetResult();

            // Выводим имя задачи
            Console.WriteLine($"Task Name: {task.Name}, {task.Time}");

            dateBase.AddTask(task);        
        }
    }
}
