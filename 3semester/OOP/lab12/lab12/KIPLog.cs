using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab12
{
    public class KIPLog
    {
        private const string PathToFile = "kiplogfile.txt";

        public static void WriteToFile(string action, string fileName, string filePath)
        {
            Data data = new Data(action, fileName, filePath);
            data.Print();
            string newData = $"{data.Date:yyyy-MM-dd HH:mm:ss}|{data.Action}|{data.FileName}|{data.FilePath}";
            using (StreamWriter sw = new StreamWriter(PathToFile, true))
            {
                sw.WriteLine(newData);
            }
        }


        public static void KeepCurrentHourRecords()
        {
            List<Data> logs = ReadLogs(); 
            var currentHourLogs = logs.Where(x => x.Date >= DateTime.Now.AddHours(-1)).ToList(); 
            using (StreamWriter sw = new StreamWriter(PathToFile, false)) 
            { 
                foreach (var log in currentHourLogs) 
                { 
                    string newData = $"{log.Date:yyyy-MM-dd HH:mm:ss}|{log.Action}|{log.FileName}|{log.FilePath}"; 
                    sw.WriteLine(newData); 
                } 
            } 
        }

                public static void FindDate(DateTime date)
        {
            List<Data> logs = ReadLogs();
            var filteredLogs = logs.Where(x => x.Date.Date == date.Date).ToList();
            filteredLogs.ForEach(x => x.Print());
        }

        private static List<Data> ReadLogs()
        {
            List<Data> logs = new List<Data>();
            if (File.Exists(PathToFile))
            {
                using (StreamReader sr = new StreamReader(PathToFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 4)
                        {
                            DateTime date = DateTime.Parse(parts[0]);
                            string action = parts[1];
                            string fileName = parts[2];
                            string filePath = parts[3];
                            logs.Add(new Data(action, fileName, filePath, date));
                        }
                    }
                }
            }
            return logs;
        }
    }

    public class Data
    {
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public Data(string action, string fileName, string filePath)
        {
            Action = action;
            FileName = fileName;
            FilePath = filePath;
            Date = DateTime.Now;
        }

        public Data(string action, string fileName, string filePath, DateTime date)
        {
            Action = action;
            FileName = fileName;
            FilePath = filePath;
            Date = date;
        }

        public void Print()
        {
            Console.WriteLine($"Action: {Action} File name: {FileName} Path: {FilePath} Date: {Date}");
        }
    }
}
