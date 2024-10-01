using System;
using System.Net;
using System.Threading.Tasks;

namespace OtusHomework10
{
    internal class ImageDownloader
    {
        public event Action? ImageStarted;
        public event Action? ImageCompleted;

        /// <summary>
        /// Создаем экземпляр класса WebClient 
        /// и асинхнонно скачиваем картинку с заданного адреса
        /// </summary>
        /// <param name="fileName"> Имя файла (можно указать путь, куда сохранится файл) </param>
        /// <param name="remoteUri"> Адрес, с которого скачивается файл</param>
        /// <returns></returns>
        public async Task Download(string fileName, string remoteUri)
        {
            using (var myWebClient = new WebClient())
            {
                ImageStarted();
                await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
                ImageCompleted();
            }
        }
    }
}
