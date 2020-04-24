using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;
using GebruikersPortaal;

namespace Adapter
{
    public class UserToPortaal : IGebruikersLijst
    {
        IDatabase db;
        public UserToPortaal(IDatabase db)
        {
            this.db = db;
        }

        public Gebruiker[] Gebruikers
        {
            get
            {
                checkConnection();
                List<User> users = db.SelectAllUsers();
                Gebruiker[] gebruikers = new Gebruiker[users.Count];
                int i = 0;
                foreach(User user in users)
                {
                    gebruikers[i] = ConvertUserGebruiker.convert(user);
                    i++;
                }
                db.CloseConnection();
                return gebruikers;
            }
        }

        private void checkConnection()
        {
            db.OpenConnection();
            if (!db.IsConnected)
            {
                throw new NotConnected();
            }
        }

        public void PasAan(Gebruiker gebruiker)
        {
            checkConnection();
            db.UpdateUser(ConvertUserGebruiker.convert(gebruiker));
            db.CloseConnection();
        }

        public void Verwijder(Gebruiker gebruiker)
        {
            checkConnection();
            db.DeleteUser(ConvertUserGebruiker.convert(gebruiker));
            db.CloseConnection();
        }

        public void VoegToe(Gebruiker gebruiker)
        {
            checkConnection();
            db.InsertUser(ConvertUserGebruiker.convert(gebruiker));
            db.CloseConnection();
        }

    }
}
