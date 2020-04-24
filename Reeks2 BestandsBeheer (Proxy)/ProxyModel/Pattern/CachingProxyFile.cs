using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyModel.Pattern
{
    class CachingProxyFile : IFile
    {
        //static dictionary containing all cached files
        private static Dictionary<string, IFile> cachedFiles = new Dictionary<string, IFile>();

        private string filename;
        private IFile file;

        //internal Constructor!!
        internal CachingProxyFile(string filename)
        {
            this.filename = filename;
        }

        public string Content
        {
            get
            {
                if(file == null)
                {
                    //checken of het al gecached is
                    if (!cachedFiles.ContainsKey(filename))
                    {
                        //read file from disk and add to cach
                        cachedFiles.Add(filename, new RealFile(filename));
                    }
                    file = cachedFiles[filename];
                }
                return file.Content;
            }
        }

    }
}
