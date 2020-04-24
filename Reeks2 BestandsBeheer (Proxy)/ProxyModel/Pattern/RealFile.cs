using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyModel.Pattern
{
    //enkel bruikbaar binnen de dll
    internal class RealFile : IFile
    {
        private string map = "C:\\test\\"; //de map waar de bestanden staan

        //protected constructor!
        internal RealFile(string filename)
        {
            LoadContentFromDisk(filename);
        }

        private void LoadContentFromDisk(string filename)
        {
            Console.Out.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Out.Write("[INF] ");
            Console.ResetColor();
            Console.Out.WriteLine("Loading file " + filename + "from disk...");
            Content = System.IO.File.ReadAllText(map + filename);
        }

        public string Content { get; private set; }
    }
}
