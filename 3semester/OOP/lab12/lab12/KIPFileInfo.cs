using System;
using System.IO;

namespace lab12
{
    public class KIPFileInfo
    {
        public void DisplayFileInfo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь: {fileInfo.FullName}");
                Console.WriteLine($"Размер файла: {fileInfo.Length} байт");
                Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}");
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }
    }
}
