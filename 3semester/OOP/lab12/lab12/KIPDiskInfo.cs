using System;
using System.IO;

namespace lab12
{
    public class KIPDiskInfo
    {
        public void DisplayDiskInfo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine($"Имя диска: {d.Name}");
                if (d.IsReady)                  // готов ли диск
                {
                    Console.WriteLine($"  Файловая система: {d.DriveFormat}");
                    Console.WriteLine($"  Объем диска: {d.TotalSize} байт");
                    Console.WriteLine($"  Доступное свободное место: {d.AvailableFreeSpace} байт");
                    Console.WriteLine($"  Общий объем свободного места: {d.TotalFreeSpace} байт");
                    Console.WriteLine($"  Метка тома: {d.VolumeLabel}");
                }
            }
        }

        public void DisplayFreeSpace(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName);
            if (drive.IsReady)
            {
                Console.WriteLine($"Свободное место на диске {driveName}: {drive.AvailableFreeSpace} байт");
            }
        }

        public void DisplayFileSystem(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName);
            if (drive.IsReady)
            {
                Console.WriteLine($"Файловая система диска {driveName}: {drive.DriveFormat}");
            }
        }
    }
}
