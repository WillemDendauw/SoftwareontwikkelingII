using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;
using GebruikersPortaal;

namespace Adapter
{
    public class PortaalToUser : IDatabase
    {
        private IGebruikersLijst gebruikerslijst;
        public PortaalToUser(IGebruikersLijst gebruikerslijst)
        {
            this.gebruikerslijst = gebruikerslijst;
        }

        public bool IsConnected => true;

        public void CloseConnection()
        {
            //niets doen
        }

        public void DeleteUser(User user)
        {
            gebruikerslijst.Verwijder(ConvertUserGebruiker.convert(user));
        }

        public void InsertUser(User user)
        {
            gebruikerslijst.VoegToe(ConvertUserGebruiker.convert(user));
        }

        public void OpenConnection()
        {
            //doe niets
        }

        public List<User> SelectAllUsers()
        {
            List<User> lijst = new List<User>();
            foreach(Gebruiker gebruiker in gebruikerslijst.Gebruikers)
            {
                lijst.Add(ConvertUserGebruiker.convert(gebruiker));
            }
            return lijst;
        }

        public void UpdateUser(User user)
        {
            gebruikerslijst.PasAan(ConvertUserGebruiker.convert(user));
        }
    }
}
