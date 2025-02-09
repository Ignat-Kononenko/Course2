using System;
using System.IO;
using System.IO.Compression;

namespace lab12
{
    public class KIPFileManager
    {
        public void InspectDirectory(string path)
        {
            string inspectDir = Path.Combine(path, "KIPInspect");
            if (!Directory.Exists(inspectDir))                                                  // существует ли каталог
            {
                Directory.CreateDirectory(inspectDir);
            }

            string dirInfoPath = Path.Combine(inspectDir, "kipdirinfo.txt");

            using (StreamWriter writer = new StreamWriter(dirInfoPath))                         // после завершения using объект writter автоматически закрыт и освобожден
            {
                writer.WriteLine("Список файлов:");
                foreach (var file in Directory.GetFiles(path))
                {
                    writer.WriteLine(file);
                }

                writer.WriteLine("\nСписок директорий:");
                foreach (var directory in Directory.GetDirectories(path))
                {
                    writer.WriteLine(directory);
                }
            }

            string copyPath = Path.Combine(inspectDir, "kipdirinfocopy.txt");
            File.Copy(dirInfoPath, copyPath);

            File.Delete(dirInfoPath);
        }

        public void CopyAndMoveFiles(string sourceDir, string fileExtension, string destinationDir)
        {
            string filesDir = Path.Combine(sourceDir, "KIPFiles");
            if (!Directory.Exists(filesDir))
            {
                Directory.CreateDirectory(filesDir);
            }

            foreach (var file in Directory.GetFiles(sourceDir, $"*{fileExtension}"))
            {
                string destFile = Path.Combine(filesDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            string finalDestination = Path.Combine(destinationDir, "KIPFiles");
            if (Directory.Exists(finalDestination))
            {
                Directory.Delete(finalDestination, true);
            }
            Directory.Move(filesDir, finalDestination);                                                 // перемещение
        }
        public void ArchiveAndExtract(string sourceDir, string destinationDir)
        {
            string zipPath = Path.Combine(sourceDir, "KIPFiles.zip");
            string filesDir = Path.Combine(sourceDir, "");
            string extractPath = Path.Combine(destinationDir, "ExtractedFiles");
            try
            {
                if (File.Exists(zipPath))
                { File.Delete(zipPath); }

                if (Directory.Exists(filesDir)) 
                { 
                    ZipFile.CreateFromDirectory(filesDir, zipPath); 
                    Console.WriteLine("Архив создан: " + zipPath); 
                } 
                else 
                { 
                    Console.WriteLine("Директория не существует: " + filesDir); 
                    return; 
                }
                if (Directory.Exists(extractPath)) 
                { 
                    Directory.Delete(extractPath, true); 
                }
              
                Directory.CreateDirectory(extractPath); ZipFile.ExtractToDirectory(zipPath, extractPath); 
                Console.WriteLine("Архив извлечен в: " + extractPath);
            }
            catch (Exception ex) { Console.WriteLine("Ошибка: " + ex.Message); }
        }
    }
}
