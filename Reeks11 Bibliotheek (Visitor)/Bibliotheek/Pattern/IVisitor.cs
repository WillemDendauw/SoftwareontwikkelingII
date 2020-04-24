using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Item;
using Bibliotheek;

namespace Bibliotheek
{
    public interface IVisitor
    {
        void Visit(Article article);
        void Visit(Book book);
        void Visit(Journal journal);
        void Visit(Library library);
    }
}
