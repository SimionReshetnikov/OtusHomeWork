using System;
using System.Collections.Generic;

namespace OtusHomework10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
    
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
            
            var initialized = imageDownloader.DownloadTaskRun();
            

            Console.WriteLine("Нажмите клавишу \"А\" для выхода или" +
                "любую другую клавишу для проверки статуса скачивания.");

            while (true)
            {
                if (Console.ReadKey().Key != ConsoleKey.A)
                {
                    for(int i = 0; i < imageDownloader.tasks.Count; i++)
                    {
                        Console.WriteLine($"\n" +
                            $"Картинка: {imageDownloader.FileNames[i]}" +
                            $" Статус:{imageDownloader.tasks[i].IsCompleted}");
                    }
                }
                else
                {
                    Console.WriteLine("\nПрограмма завершена.");
                    
                    break;
                }
            }
        }
    }
}
