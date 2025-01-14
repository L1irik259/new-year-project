using System;
using System.Threading;
using System.Threading.Tasks;
using TaskManagementSystem.Models.TelegBot;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TaskManagementSystem.Models.TelegBot.CreatMyTask;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem
{
    class Program2
    {
        // DateBase dateBase = DateBase.GetInstance();
        // static ITelegramBotClient bot = new TelegramBotClient("7937143525:AAGvcB94t_SsRLrU2B_ToTtTxZaqLfhYMsQ");

        static TelegramBot bot = TelegramBot.GetInstance();

        static Dictionary<long, string> userStates = new Dictionary<long, string>();
        static List<string> listForMyTask = [];
        private static int count = 0;

        [Obsolete]
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message != null)
            {
                var message = update.Message;

                // Console.WriteLine($"Received a message from {message.Chat.Username}: {message.Text}");

                // Инициализация цепочки
                var startHandler = new StartHandler();
                var nameHandler = new NameHandler();
                var statusHandler = new StatusHandler();
                var commentHandler = new CommentHandler();
                var timeHandler = new TimeHandler();
                var timeWhenRemindHandler = new TimeWhenRemindHandler();

                startHandler.SetNext(nameHandler);
                nameHandler.SetNext(statusHandler);
                statusHandler.SetNext(commentHandler);
                commentHandler.SetNext(timeHandler);
                timeHandler.SetNext(timeWhenRemindHandler);

                // Передаём управление в цепочку
                await startHandler.HandleAsync(botClient, message, userStates, listForMyTask);
                count++;
            }
            
            Console.WriteLine(count);

            if (count == 6)
            {
            DateBase dateBase = DateBase.GetInstance();

            MyTask task = new TaskBuilder()
                                    .WithId()
                                    .WithTaskStatus(int.Parse(listForMyTask[1]))
                                    .WithTime(DateTime.Parse(listForMyTask[3]))
                                    .WithName(listForMyTask[0])
                                    .WithComment(listForMyTask[2])
                                    .WithTimeWhenRemind(DateTime.Parse(listForMyTask[4]))
                                    .GetResult();                   

            Console.WriteLine($"{task.Id}, {task.Name}, {task.Comment}, {task.TaskStatus}, {task.Time}, {task.TimeWhenRemind}");
            dateBase.AddTask(task);

            count = 0;
            listForMyTask.Clear();
            }                        
        }

        [Obsolete]
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск Telegram-бота...");

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
            };

            bot.GetBotClient().StartReceiving(
                HandleUpdateAsync,
                (bot, ex, token) => Task.CompletedTask,
                receiverOptions,
                cancellationToken);

            Console.WriteLine("Бот запущен. Нажмите Enter для завершения.");
            Console.ReadLine();

            // Останавливаем бота при завершении работы приложения
            cts.Cancel();
        }
    }
}