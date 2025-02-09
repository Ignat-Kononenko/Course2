using System;
using System.IO;

namespace lab12
{
    public class KIPDirInfo
    {
        public void DisplayDirInfo(string dirPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            string tempFile = Path.GetTempFileName();

            if (dirInfo.Exists)
            {
                Console.WriteLine($"Полный путь: {dirInfo.FullName}");
                Console.WriteLine($"Время создания: {dirInfo.CreationTime}");
                Console.WriteLine($"Количество файлов: {dirInfo.GetFiles().Length}");
                Console.WriteLine($"Количество поддиректориев: {dirInfo.GetDirectories().Length}");
                Console.WriteLine("Список родительских директориев:");
                Console.WriteLine(tempFile);

                DirectoryInfo parentDir = dirInfo.Parent;
                while (parentDir != null)
                {
                    Console.WriteLine(parentDir.FullName);
                    parentDir = parentDir.Parent;
                }
            }
            else
            {
                Console.WriteLine("Директория не существует.");
            }
        }
    }
}
