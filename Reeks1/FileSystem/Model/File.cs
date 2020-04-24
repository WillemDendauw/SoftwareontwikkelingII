using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Model
{
    public abstract class File
    {
        string name;
        public File(string name)
        {
            if(name == null)
            {
                throw new FileSystemException("name is null");
            }
            if (name.Contains("/"))
            {
                throw new FileSystemException(name + " bevat /");
            }
            this.name = name;
        }

        public Folder Parent { get; set; }

        public string Name
        {
            get { return name; }
        }

        public bool IsRoot
        {
            get { return Parent == null;  }
        }

        public string PathName
        {
            get
            {
                if (IsRoot)
                {
                    return Name;
                }
                else
                {
                    return Parent.PathName + "/" + Name;
                }
            }
        }

        public abstract string ListName { get; }

        public virtual void PrintTree(int indent)
        {
            for(int i = 0; i<indent; i++)
            {
                Console.Out.Write("  ");
            }
            Console.Out.WriteLine(ListName);
        }
    }
}
