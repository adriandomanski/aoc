using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_22_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("test.txt");
            
            file = File.OpenText("dane.txt");
            dir mainDir = null;
            dir currentDir = null;
            List<dir> allDirs = new List<dir>();
            string s = "";
            var linesimple = new List<string>();

            while ((s = file.ReadLine()) != null)
            {
                linesimple.Add(s);
                if (s.StartsWith("$ cd /"))
                {
                    mainDir = new dir() { dirName = s.Replace("$ cd ", "") };
                    currentDir = mainDir;
                    allDirs.Add(mainDir);

                }
                else
                if (int.TryParse(s.Split(' ')[0], out int sizefile))
                {
                    currentDir.files.Add(new fil { name = s.Split(' ')[1], size = sizefile });
                }
                else
                    if (s.StartsWith("$ cd .."))
                {
                    currentDir = currentDir.parent;
                }
                else
                    if (s.StartsWith("$ cd"))
                {
                    var dd = new dir() { dirName = s.Replace("$ cd ", "") };
                    dd.parent = currentDir;
                    currentDir.dirs.Add(dd);
                    currentDir = dd;
                    allDirs.Add(currentDir);


                }
            }


            int currentFreeSpace = 70000000 - mainDir.GetSize();

            var subsize = allDirs.OrderByDescending(d => d.GetSize()).ToList();

            var subDIrs = allDirs.Where(d => d.GetSize() >= (30000000 - currentFreeSpace)).OrderBy(d => d.GetSize()).ToList();
            Console.WriteLine("stage one: " + allDirs.Where(d => d.GetSize() < 100000).Sum(d => d.GetSize()));
            Console.ReadLine();

        





            Console.ReadLine();
        }
        class dir
        {
            public string dirName { get; set; }
            public dir parent { get; set; }
            public List<dir> dirs = new List<dir>();
            public List<fil> files = new List<fil>();
            public int GetSize(){ return files.Sum(f => f.size) + dirs.Sum(d => d.GetSize()); }
            public int MyProperty { get { return GetSize(); } }

            public override string ToString()
            {
                return dirName + " size: " + GetSize();
            }
        }
        class fil
        {
            public int size = 0;
            public string name = "";
            public override string ToString()
            {
                return size + " " + name;
            }
        }
    }
}
