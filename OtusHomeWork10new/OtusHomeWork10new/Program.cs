namespace OtusHomeWork10new
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var imageDownloader = new ImageDownloader();

            imageDownloader.ImageStarted += () => Console.WriteLine("Скачивание файла началось");
            imageDownloader.ImageCompleted += () => Console.WriteLine("Скачивание файла закончилось");

            imageDownloader.Download("ge.jpg",
                remoteUri: "https://webneel.com/daily/sites/default/files/images/daily/08-2018/1-nature-photography-spring-season-mumtazshamsee.jpg");
            
            Console.WriteLine("Введите любую клавишу для выхода");
            Console.ReadLine();
        }
    }
}
