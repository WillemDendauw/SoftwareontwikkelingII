using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Model
{
    public class TextFile : File
    {
        public string Inhoud { get; set; }

        public TextFile(string name, string inhoud) : base(name)
        {
            this.Inhoud = inhoud;
        }

        public override string ListName => Name;
    }
}
