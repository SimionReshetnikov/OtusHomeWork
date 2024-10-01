using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OtusHomework10
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            CancellationTokenSource cts = new CancellationTokenSource();
            var token = cts.Token;
            List<string> fileName = new List<string>();
            List<Task> tasks = new List<Task>();
            var randomNumber = new Random();

            for(int i = 0; i < 10; i++)
            {
                fileName.Add($"C:\\Users\\kiram\\Desktop\\Учеба программированию\\newPhoto{randomNumber.Next(1000)}.jpg");
            }

            var imageDownloader = new ImageDownloader();

            imageDownloader.ImageStarted +=
                () => Console.WriteLine("Скачивание файла началось.");

            imageDownloader.ImageCompleted +=
                () => Console.WriteLine("Скачивание файла закончилось.");
            
            var initialized = (DownloadTaskRun(tasks, fileName, imageDownloader), token);

            Console.WriteLine("Нажмите клавишу \"А\" для выхода или" +
                "любую другую клавишу для проверки статуса скачивания.");

            while (true)
            {
                if (Console.ReadKey().Key != ConsoleKey.A)
                {
                    for(int i = 0; i < fileName.Count; i++)
                    {
                        Console.WriteLine($"\n" +
                            $"Картинка: {fileName[i]}" +
                            $" Статус:{tasks[i].IsCompleted}");
                    }
                }
                else
                {
                    cts.Cancel();
                    break;
                }
            }

            if (initialized.token.IsCancellationRequested)
            {
                Console.WriteLine("\nПрограмма остановлена.");
            }

            cts.Dispose();
        }

        /// <summary>
        /// Добавляем все Task в лист tasks
        /// await Task.WhenAll(tasks) - ожидаем, когда все Task выполнятся
        /// </summary>
        /// <returns></returns>

        public static async Task DownloadTaskRun(List<Task> tasks, List<string> list, ImageDownloader imageDownloader)
        {
            
            for (int i = 0; i < list.Count; i++)
            {
                tasks.Add(imageDownloader.Download(list[i],
                    "https://webneel.com/daily/sites/default/files/images/daily/08-2018/1-nature-photography-spring-season-mumtazshamsee.jpg"));
            }

            await Task.WhenAll(tasks);
        }
    }
}
