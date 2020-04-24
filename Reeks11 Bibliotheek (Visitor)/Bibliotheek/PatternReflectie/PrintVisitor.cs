using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Item;

namespace Bibliotheek.PatternReflectie
{
    public class PrintVisitor : AVisitor
    {
        private int totaal = 0;
        public override void Visit(Article article)
        {
            totaal += article.NumberOfPages;
        }

        public override void Visit(Book book)
        {
            totaal += book.NumberOfPages;
        }

        public override void Visit(Journal journal)
        {
            foreach(Article article in journal.Articles)
            {
                Visit(article);
            }
        }

        protected override void Show()
        {
            Console.WriteLine("Aantal pagina's: " + totaal);
        }
    }
}
