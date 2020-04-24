using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;
using GebruikersPortaal;

namespace Adapter
{
    public class ConvertUserGebruiker
    {
        static public Gebruiker convert(User user)
        {
            Gebruiker gebruiker = new Gebruiker
            {
                Achternaam = user.LastName,
                VoorNaam = user.FirstName,
                GebruikersCode = user.ID
            };
            return gebruiker;
        }

        public static User convert(Gebruiker gebruiker)
        {
            User user = new User
            {
                LastName = gebruiker.Achternaam,
                FirstName = gebruiker.VoorNaam,
                ID = gebruiker.GebruikersCode
            };
            return user;
        }
    }
}
