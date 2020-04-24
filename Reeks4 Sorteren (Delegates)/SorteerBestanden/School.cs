using System.Text;

namespace SorteerBestanden
{
    public class School
    {
        public string Id { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Type { get; set; }
        public string Net { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id);
            sb.Append(";");
            sb.Append(Naam);
            sb.Append(";");
            sb.Append(Adres);
            sb.Append(";");
            sb.Append(Type);
            sb.Append(";");
            sb.Append(Net);
            sb.Append(";");
            return sb.ToString();
        }
    }
}
