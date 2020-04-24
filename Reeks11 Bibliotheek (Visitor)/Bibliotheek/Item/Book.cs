using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheek.Item
{
    public class Book : LibraryItem
    {

        public Book(string author, string title, int numberOfPages) : base(title)
        {
            Author = author;
            NumberOfPages = numberOfPages;
        }

        public string Author { get; }

        public int NumberOfPages
        {
            get;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
