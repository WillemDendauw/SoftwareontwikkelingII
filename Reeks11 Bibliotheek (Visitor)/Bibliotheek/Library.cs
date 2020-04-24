using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Item;

namespace Bibliotheek
{
    public class Library
    {
        public Library()
        {
            Items = new List<LibraryItem>();
            Init();
        }

        public IEnumerable<string> Titles
        {
            get
            {
                foreach(LibraryItem item in Items)
                {
                    yield return "-" + item.Title;
                    if(item is Journal)
                    {
                        Journal journal = (Journal)item;
                        foreach(Article article in journal.Articles)
                        {
                            yield return "--" + article.Title;
                        }
                    }
                }
            }
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public List<LibraryItem> Items { get; }

        private void Init()
        {
            Items.Add(new Book("Geert Colpaert", "Het boek der ontwenning", 759));
            Items.Add(new Book("Christophe Vekeman", "Marie", 189));
            List<Article> articles = new List<Article>();
            articles.Add(new Article("Tom Engelshoven", "Tom Barman", 44, 48));
            articles.Add(new Article("Tom Engelshoven", "Bruce Springsteen", 40, 43));
            articles.Add(new Article("Willem Jongeneelen", "Het geluk van België", 50, 55));
            articles.Add(new Article("Swie Tio", "Never mind The Sex Pistols, here's the ... Buzzcocks", 62, 67));
            Items.Add(new Journal("Oor", articles));
            Items.Add(new Book("Sarah Lark", "De roep van het land", 604));
            articles = new List<Article>();
            articles.Add(new Article("Ivo De Kock", "Beasts of the southern wild : levendig, magisch en realistisch", 12, 13));
            articles.Add(new Article("Sarah Skoric", "Ice dragon : Zweedse ninja's on the road", 20, 21));
            articles.Add(new Article("Ivo De Kock", "Killing them softly : dit is geen land maar een business", 22, 23));
            articles.Add(new Article("Dirk Michiels", "Le capital : dissectie van het bankkapitalisme", 24, 25));
            articles.Add(new Article("Piet Goethals", "Skyfall : ravissant, schizofreen en gedenkwaardig", 29, 29));
            Items.Add(new Journal("Filmmagie", articles));
        }
    }
}
