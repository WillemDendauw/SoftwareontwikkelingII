using System;
using System.Collections.Generic;
using Bibliotheek.Item;

namespace Bibliotheek
{
    public class CountVisitor : IVisitor
    {
        private int totaal = 0;
        public void Visit(Article article)
        {
            totaal += article.NumberOfPages;
        }

        public void Visit(Book book)
        {
            totaal += book.NumberOfPages;
        }

        public void Visit(Journal journal)
        {
            List<Article> articles = journal.Articles;
            foreach(Article art in articles)
            {
                totaal += art.NumberOfPages;
            }
        }

        public void Visit(Library library)
        {
            foreach(LibraryItem item in library.Items)
            {
                item.Accept(this);
            }
            Console.WriteLine("Aantal paginas: " + totaal);
        }
    }
}
