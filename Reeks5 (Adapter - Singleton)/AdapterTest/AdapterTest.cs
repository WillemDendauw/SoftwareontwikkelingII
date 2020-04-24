using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adapter;
using UserDatabase;
using GebruikersPortaal;
using System.Collections.Generic;
using System.Linq;

namespace AdapterTest
{
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void TestGebruikersPortaal()
        {
            IGebruikersLijst lijst = new GebruikersLijst();

            Gebruiker g = new Gebruiker() { GebruikersCode = 1, VoorNaam = "John", Achternaam = "Doe" };
            lijst.VoegToe(g);
            List<Gebruiker> list = new List<Gebruiker>(lijst.Gebruikers);
            Assert.IsTrue(list.Contains(g));

            g.VoorNaam = "Jane";
            lijst.PasAan(g);
            list = new List<Gebruiker>(lijst.Gebruikers);
            Gebruiker test = list.First(s => s.GebruikersCode == 1);
            Assert.AreEqual("Jane", test.VoorNaam);

            lijst.Verwijder(g);
            list = new List<Gebruiker>(lijst.Gebruikers);
            Assert.IsFalse(list.Contains(g));
        }

        [TestMethod]
        public void TestUserDatabase()
        {
            IDatabase db = new MySQLDatabase();

            db.OpenConnection();
            Assert.IsTrue(db.IsConnected);

            User u = new User() { ID = 1, FirstName = "John", LastName = "Doe" };
            db.InsertUser(u);
            Assert.IsTrue(db.SelectAllUsers().Contains(u));

            u.FirstName = "Jane";
            db.UpdateUser(u);
            User test = db.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("Jane", test.FirstName);

            db.DeleteUser(u);
            Assert.IsFalse(db.SelectAllUsers().Contains(u));

            db.CloseConnection();
            Assert.IsFalse(db.IsConnected);
        }

        [TestMethod]
        public void TestGebruikerToUserAdapter()
        {
            IGebruikersLijst lijst = new GebruikersLijst();
            PortaalToUser adapter = new PortaalToUser(lijst);

            User u = new User() { ID = 1, FirstName = "John", LastName = "Doe" };
            adapter.InsertUser(u);
            List<Gebruiker> list = new List<Gebruiker>(lijst.Gebruikers);
            Gebruiker test = list.First(s => s.GebruikersCode == 1);
            Assert.AreEqual("John", test.VoorNaam);
            Assert.AreEqual("Doe", test.Achternaam);

            u.FirstName = "Jane";
            adapter.UpdateUser(u);
            list = new List<Gebruiker>(lijst.Gebruikers);
            test = list.FirstOrDefault(s => s.GebruikersCode == 1);
            Assert.AreEqual("Jane", test.VoorNaam);

            adapter.DeleteUser(u);
            list = new List<Gebruiker>(lijst.Gebruikers);
            test = list.FirstOrDefault(s => s.GebruikersCode == 1);
            Assert.IsNull(test);
        }

        [TestMethod]
        public void TestUserToGebruikerAdapter()
        {
            IDatabase db = new MySQLDatabase();
            UserToPortaal adapter = new UserToPortaal(db);
            Gebruiker g = new Gebruiker() { GebruikersCode = 1, VoorNaam = "John", Achternaam = "Doe" };
            adapter.VoegToe(g);
            db.OpenConnection();
            User test = db.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("John", test.FirstName);
            Assert.AreEqual("Doe", test.LastName);
            db.CloseConnection();

            g.VoorNaam = "Jane";
            adapter.PasAan(g);
            db.OpenConnection();
            test = db.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("Jane", test.FirstName);
            db.CloseConnection();

            adapter.Verwijder(g);
            db.OpenConnection();
            test = db.SelectAllUsers().FirstOrDefault(s => s.ID == 1);
            Assert.IsNull(test);
            db.CloseConnection();
        }
    }
}
