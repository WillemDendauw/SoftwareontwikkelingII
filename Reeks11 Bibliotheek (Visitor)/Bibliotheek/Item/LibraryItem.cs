using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheek.Item
{
    public abstract class LibraryItem
    {
        public string Title { get; }

        public LibraryItem(string title)
        {
            Title = title;
        }

        public abstract void Accept(IVisitor visitor);
    }
}
