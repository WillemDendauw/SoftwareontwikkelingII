using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Item;

namespace Bibliotheek.PatternReflectie
{
    public interface IVisitor
    {
        void ReflectiveVisit(LibraryItem element);

        void Visit(Library library);
    }
}
