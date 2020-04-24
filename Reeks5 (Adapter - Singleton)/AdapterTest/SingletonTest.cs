using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserDatabase;
using Adapter;
using System.Linq;

namespace AdapterTest
{
    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        public void TestSingletonDatabase()
        {
            IDatabase db = SingletonDatabase.Instance;
            IDatabase db2 = SingletonDatabase.Instance;

            Assert.AreEqual(db, db2);

            User u = new User() { ID = 1, FirstName = "John", LastName = "Doe" };
            db.InsertUser(u);
            Assert.IsTrue(db.SelectAllUsers().Contains(u));
            Assert.IsTrue(db2.SelectAllUsers().Contains(u));

            // Wijzig user
            u.FirstName = "Jane";
            db.UpdateUser(u);
            User test = db.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("Jane", test.FirstName);
            test = db2.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("Jane", test.FirstName);

            // Verwijder user
            db.DeleteUser(u);
            Assert.IsFalse(db.SelectAllUsers().Contains(u));
            Assert.IsFalse(db2.SelectAllUsers().Contains(u));
        }
    }
}
