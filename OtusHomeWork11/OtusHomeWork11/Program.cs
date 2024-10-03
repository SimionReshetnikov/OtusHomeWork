using System.Diagnostics.Tracing;
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

            CreateFiles(directoryFirst.FullName);
            await WriteToFileAsync(directoryFirst.GetFiles());
            await ReadAllFilesAsync(directoryFirst.GetFiles());

            var directorySecond = new DirectoryInfo(@"C:\Otus\TestDir2");

            if (!directorySecond.Exists)
            {
                directorySecond.Create();
            }

            CreateFiles(directorySecond.FullName);
            await WriteToFileAsync(directorySecond.GetFiles());
            await ReadAllFilesAsync(directorySecond.GetFiles());
        }

        private static void CreateFiles(string fullNameDirectory)
        {

            for (int i = 1; i <= 10; i++) 
            {
                using var fileStream = File.Create($@"{fullNameDirectory}\Test{i}.txt");
            }

            Console.WriteLine("Файлы созданы");
        }

        private static async Task WriteToFileAsync(FileInfo[] fileInfo)
        {
            foreach (var file in fileInfo)
            {
                file.Refresh();
                try
                {
                    if (file.Exists)
                    {
                        Byte[] info =
                                new UTF8Encoding(true).GetBytes(file.Name);

                        Byte[] infoDateTime =
                                new UTF8Encoding(true).GetBytes($" {DateTime.Now}");

                        using (var fs = file.OpenWrite())
                        {
                            await fs.WriteAsync(info, 0, info.Length);
                            await fs.WriteAsync(infoDateTime, 0, infoDateTime.Length);
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException($"Файл {file.Name} не существует.");
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static async Task ReadAllFilesAsync(FileInfo[] fileInfo)
        {

            foreach(var file in fileInfo)
            {
                file.Refresh();
                if(file.Exists)
                {
                    using (var fileStream = new FileStream(file.FullName, FileMode.Open,
                    FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
                    {
                        byte[] buffer = new byte[4096];
                        int numRead;
                        var sb = new StringBuilder();

                        while ((numRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                        {
                            string text = Encoding.UTF8.GetString(buffer, 0, numRead);
                            sb.Append(text);
                        }

                        Console.WriteLine(sb.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"Файл {file.Name} не существует.");
                }
            }
        }
    }
}
