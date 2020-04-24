using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Item;

namespace Bibliotheek.PatternReflectie
{
    public abstract class AVisitor : IVisitor
    {
        public void ReflectiveVisit(LibraryItem element)
        {
            Type[] types = new Type[] { element.GetType() };

            MethodInfo methodInfo = this.GetType().GetMethod("Visit", types);

            methodInfo?.Invoke(this, new object[] { element });
        }

        public void Visit(Library library)
        {
            foreach(LibraryItem item in library.Items)
            {
                ReflectiveVisit(item);
            }
            Show();
        }

        public abstract void Visit(Article article);
        public abstract void Visit(Book book);
        public abstract void Visit(Journal journal);

        protected abstract void Show();
    }
}
