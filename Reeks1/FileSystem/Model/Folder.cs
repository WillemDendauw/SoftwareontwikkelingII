using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Model
{
    public class Folder : File
    {
        HashSet<File> bestanden = new HashSet<File>();

        public Folder(string name) : base(name)
        {
        }

        public File GetFile(string name)
        {
            foreach (File f in bestanden)
            {
                if (f.Name.Equals(name))
                {
                    return f;
                }

            }
            return null;
        }

        //indexer
        public File this[string name]
        {
            get
            {
                return GetFile(name);
            }
        }

        private void CheckName(string name)
        {
            if (GetFile(name) != null)
            {
                throw new FileSystemException("Map bevat al bestand met naam '" + name + "'");
            }
            if (name.Equals(""))
            {
                throw new FileSystemException("Lege naam niet toegelaten");
            }
        }

        public TextFile CreateTextFile(string name)
        {
            CheckName(name);
            TextFile file = new TextFile(name, "");
            bestanden.Add(file);
            return file;
        }

        public Folder CreateFolder(string name)
        {
            CheckName(name);
            Folder map = new Folder(name);
            bestanden.Add(map);
            return map;
        }

        public override string ListName => Name + "/";

        public void PrintList()
        {
            foreach(File f in bestanden)
            {
                Console.WriteLine(f.ListName);
            }
        }

        public override void PrintTree(int indent)
        {
            base.PrintTree(indent);
            foreach(File f in bestanden)
            {
                f.PrintTree(indent + 1);
            }
        }
    }
}
