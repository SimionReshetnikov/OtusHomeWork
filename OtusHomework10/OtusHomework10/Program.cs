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
            List<string> list = new List<string>();
            var randomNumber = new Random();

            for(int i = 0; i < 10; i++)
            {
                list.Add($"C:\\Users\\kiram\\Desktop\\Учеба программированию\\newPhoto{randomNumber.Next(1000)}.jpg");
            }

            var imageDownloader = new ImageDownloader(list);

            imageDownloader.ImageStarted +=
                () => Console.WriteLine("Скачивание файла началось.");

            imageDownloader.ImageCompleted +=
                () => Console.WriteLine("Скачивание файла закончилось.");
            
            var initialized = (DownloadTaskRun(imageDownloader), token);

            Console.WriteLine("Нажмите клавишу \"А\" для выхода или" +
                "любую другую клавишу для проверки статуса скачивания.");

            while (true)
            {
                if (Console.ReadKey().Key != ConsoleKey.A)
                {
                    for(int i = 0; i < imageDownloader.Tasks.Count; i++)
                    {
                        Console.WriteLine($"\n" +
                            $"Картинка: {imageDownloader.FileNames[i]}" +
                            $" Статус:{imageDownloader.Tasks[i].IsCompleted}");
                    }
                }
                else
                {
                    cts.Cancel();
                    cts.Dispose();
                    Console.WriteLine("\nПрограмма завершена.");
                    break;
                }
            }
        }

        /// <summary>
        /// Добавляем все Task в лист tasks
        /// await Task.WhenAll(tasks) - ожидаем, когда все Task выполнятся
        /// </summary>
        /// <returns></returns>

        public static async Task DownloadTaskRun(ImageDownloader imageDownloader)
        {
            imageDownloader.Tasks = new List<Task>();
            for (int i = 0; i < imageDownloader.FileNames.Count; i++)
            {
                imageDownloader.Tasks.Add(imageDownloader.Download(imageDownloader.FileNames[i],
                    "https://webneel.com/daily/sites/default/files/images/daily/08-2018/1-nature-photography-spring-season-mumtazshamsee.jpg"));
            }
            await Task.WhenAll(imageDownloader.Tasks);
        }
    }
}
