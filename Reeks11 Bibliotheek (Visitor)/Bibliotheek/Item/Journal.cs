using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheek.Item
{
    public class Journal : LibraryItem
    {

        public Journal(string title, List<Article> articles) : base(title)
        {
            Articles = articles;
        }

        public List<Article> Articles { get; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
