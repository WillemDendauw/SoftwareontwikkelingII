using System.Text;

namespace SorteerBestanden
{
    public class Park
    {
        public string Id { get; set; }
        public string Naam { get; set; }
        public string Oppervlakte { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id);
            sb.Append(";");
            sb.Append(Naam);
            sb.Append(";");
            sb.Append(Oppervlakte);
            sb.Append(";");
            return sb.ToString();
        }
    }
}
