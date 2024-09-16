using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OtusHomework10
{
    internal class ImageDownloader
    {
        public List<Task> tasks { get; set; }
        public List<string> FileNames { get; set; }
        public event Action ImageStarted;
        public event Action ImageCompleted;

        public ImageDownloader(List<string> fileNames)
        {
            FileNames = fileNames;
        }

        /// <summary>
        /// Создаем экземпляр класса WebClient 
        /// и асинхнонно скачиваем картинку с заданного адреса
        /// </summary>
        /// <param name="fileName"> Имя файла (можно указать путь, куда сохранится файл) </param>
        /// <param name="remoteUri"> Адрес, с которого скачивается файл</param>
        /// <returns></returns>
        private async Task Download(string fileName, string remoteUri)
        {
            var myWebClient = new WebClient();
            ImageStarted();
            await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            ImageCompleted();
        }

        /// <summary>
        /// Добавляем все Task в лист tasks
        /// await Task.WhenAll(tasks) - ожидаем, когда все Task выполнятся
        /// </summary>
        /// <returns></returns>
        public async Task DownloadTaskRun()
        {
            tasks = new List<Task>();
            for(int i = 0; i < FileNames.Count; i++)
            {
                tasks.Add(Download(FileNames[i],
                    "https://webneel.com/daily/sites/default/files/images/daily/08-2018/1-nature-photography-spring-season-mumtazshamsee.jpg"));
            }
            await Task.WhenAll(tasks);
        }
    }
}
