using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace DirectoryInfoAndFile
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowWindowsDirectory();
        }
        static void ShowWindowsDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            //FileInfo f = new FileInfo(dir + "test.txt");
            //FileStream fs = f.Create();
            string[] myTasks = { "helower","afafasfa dfafa","dfdsfdasf afdf","dfadafwe ewrw w"};
            File.WriteAllLines(dir.ToString() + @"test.txt", myTasks);
            foreach (string s in File.ReadAllLines(dir.ToString() + @"test.txt"))
            {
                Console.WriteLine(s);
            }
            //fs.Close();
            Console.WriteLine(dir.FullName);
            Console.WriteLine(dir.Name);
            Console.WriteLine(dir.Parent.Parent);
            Console.WriteLine(dir.Root);
            Console.WriteLine(dir.CreationTime);
            dir.CreateSubdirectory("Test");
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"Test\data");
            Console.WriteLine("New Folder is :{0}", myDataFolder);
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo s in drivers)
            {
                Console.WriteLine(s.Name);
                if (s.IsReady)
                {
                    Console.WriteLine(s.RootDirectory);
                    Console.WriteLine(s.DriveFormat);
                    Console.WriteLine(s.DriveType);
                    Console.WriteLine(s.TotalSize);
                    Console.WriteLine(s.TotalFreeSpace);
                }
            }

        }
    }
}
