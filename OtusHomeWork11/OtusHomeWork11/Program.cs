using System.Text;

namespace OtusHomeWork11
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var directoryFirst = new DirectoryInfo(@"C:\Otus\TestDir1");

            if(!directoryFirst.Exists)
            {
                directoryFirst.Create();
            }

            CreateFiles(directoryFirst);
            await WriteToFile(directoryFirst.GetFiles());
            ReadAllFiles(directoryFirst.GetFiles());

            var directorySecond = new DirectoryInfo(@"C:\Otus\TestDir2");

            if (!directorySecond.Exists)
            {
                directorySecond.Create();
            }

            CreateFiles(directorySecond);
            await WriteToFile(directorySecond.GetFiles());
            ReadAllFiles(directorySecond.GetFiles());
        }

        private static void CreateFiles(DirectoryInfo directory)
        {

            if(directory.Name == "TestDir1")
            {
                for (int i = 1; i <= 10; i++)
                {
                    using var fileStream = File.Create($@"C:\Otus\TestDir1\File{i}.txt");
                }
            }
            else
            {
                for (int i = 1; i <= 10; i++)
                {
                    using var fileStream = File.Create($@"C:\Otus\TestDir2\File{i}.txt");
                }
            }

            Console.WriteLine("Файлы созданы");
        }

        private static async Task WriteToFile(FileInfo[] fileInfo)
        {
            List<Task> task = new List<Task>();

            try
            {
                foreach (var file in fileInfo)
                {
                    if (file.Exists)
                    {
                        Byte[] info =
                                new UTF8Encoding(true).GetBytes(file.Name);

                        Byte[] infoDateTime =
                                new UTF8Encoding(true).GetBytes($" {DateTime.Now}");

                        using (var fs = file.OpenWrite())
                        {
                            task.Add(fs.WriteAsync(info, 0, info.Length));
                            task.Add(fs.WriteAsync(infoDateTime, 0, infoDateTime.Length));
                        }
                    }
                }

                await Task.WhenAll();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReadAllFiles(FileInfo[] fileInfo)
        {
            foreach(var file in fileInfo)
            {
                using (var reader = file.OpenText())
                {
                    string textFile = "";

                    while((textFile = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"{file.Name}: {textFile}");
                    }
                }
            }
        }
    }
}
