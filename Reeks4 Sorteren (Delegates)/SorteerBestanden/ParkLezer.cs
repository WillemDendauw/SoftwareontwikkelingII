namespace SorteerBestanden
{
    public class ParkLezer
    {
        public static Park LeesPark(string invoer)
        {
            string[] stukjes = invoer.Split(';');
            Park park = new Park();
            park.Id = stukjes[1];
            park.Naam = stukjes[6];
            park.Oppervlakte = stukjes[8];
            return park;
        }
    }
}
