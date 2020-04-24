using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Item;

namespace Bibliotheek.PatternReflectie
{
    public class AuteursVisitor : AVisitor
    {
        private HashSet<string> auteurs = new HashSet<string>();
        public override void Visit(Article article)
        {
            auteurs.Add(article.Author);
        }

        public override void Visit(Book book)
        {
            auteurs.Add(book.Author);
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
            Console.WriteLine("Auteurs (" + auteurs.Count + ")");
            foreach(string auteur in auteurs)
            {
                Console.WriteLine(auteur);
            }
        }
    }
}
