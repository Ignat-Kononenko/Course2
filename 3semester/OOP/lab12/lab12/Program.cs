using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KIPLog.WriteToFile("Создание файла", "kiplogfile.txt", ":D\\...");

            KIPLog.FindDate(DateTime.Now);
            DateTime specificDate = DateTime.Now; 
            Console.WriteLine("\nЗаписи за конкретную дату:");
            KIPLog.FindDate(specificDate);
            Console.WriteLine("\nОставить только записи за текущий час:");
            KIPLog.KeepCurrentHourRecords();

            KIPDiskInfo diskInfo = new KIPDiskInfo();
            diskInfo.DisplayDiskInfo();
            diskInfo.DisplayFreeSpace("D");

            KIPFileInfo fileInfo = new KIPFileInfo();
            string filePath = "D:\\labs\\3semestr\\ООП\\lab12\\lab12\\lab12\\bin\\Debug\\kiplogfile.txt";
            fileInfo.DisplayFileInfo(filePath);

            KIPDirInfo dirInfo = new KIPDirInfo();
            string dirName = "D:\\\\labs\\\\3semestr\\\\ООП";
            dirInfo.DisplayDirInfo(dirName);

            KIPFileManager fileManager = new KIPFileManager();
            string sourcePath = "D:\\labs\\3semestr\\ООП\\lab12\\lab12\\lab12\\bin\\Debug";
            string destinationPath = "D:\\labs\\3semestr\\ООП\\lab12\\lab12\\lab12\\bin\\Debug\\kiplogfile.txt";
            fileManager.ArchiveAndExtract(sourcePath, destinationPath);


        }
    }
}
