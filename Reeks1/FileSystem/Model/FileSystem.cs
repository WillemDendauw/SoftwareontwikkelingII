using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Model
{
    public class FileSystem
    {
        Folder root;
        Folder cur;

        public FileSystem()
        {
            root = new Folder("");
            cur = root;
        }

        public void mktext(string name)
        {
            try
            {
                File f = cur.CreateTextFile(name);
                f.Parent = cur;
            }
            catch (FileSystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void mkdir(string name)
        {
            try
            {
                Folder map = cur.CreateFolder(name);
                map.Parent = cur;
            }
            catch(FileSystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void dir()
        {
            cur.PrintList();
        }

        public void tree()
        {
            cur.PrintTree(0);
        }

        public void cd(string pad)
        {
            if (pad.Equals("/"))
            {
                cur = root;
            }
            else if (pad.Equals(".."))
            {
                if (!cur.IsRoot)
                {
                    cur = cur.Parent;
                }
            }
            else
            {
                try
                {
                    File f = cur[pad];
                    if(f is Folder)
                    {
                        cur = (Folder)f;
                    }
                    else
                    {
                        Console.WriteLine("Ongeldig pad");
                    }
                }
                catch(FileSystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
