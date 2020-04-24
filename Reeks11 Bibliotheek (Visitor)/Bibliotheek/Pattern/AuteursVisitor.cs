using System;
using System.Collections.Generic;
using Bibliotheek.Item;

namespace Bibliotheek.Pattern
{
    class AuteursVisitor : IVisitor
    {
        private HashSet<string> auteurs = new HashSet<string>();

        public void Visit(Article article)
        {
            auteurs.Add(article.Author);
        }

        public void Visit(Book book)
        {
            auteurs.Add(book.Author);
        }

        public void Visit(Journal journal)
        {
            foreach(Article article in journal.Articles)
            {
                article.Accept(this);
            }
        }

        public void Visit(Library library)
        {
            foreach(LibraryItem item in library.Items)
            {
                item.Accept(this);
            }
            Console.WriteLine("Auteurs (" + auteurs.Count + "):");
            foreach(string auteur in auteurs)
            {
                Console.WriteLine(auteur);
            }
        }
    }
}
