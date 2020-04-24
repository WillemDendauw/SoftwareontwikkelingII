namespace SorteerBestanden
{
    public class SchoolLezer
    {
        public static School LeesSchool(string invoer)
        {
            string[] stukjes = invoer.Split(';');
            School school = new School();
            school.Id = stukjes[3];
            school.Naam = stukjes[6];
            school.Adres = stukjes[5];
            school.Type = stukjes[7];
            school.Net = stukjes[8];
            return school;
        }
    }
}
