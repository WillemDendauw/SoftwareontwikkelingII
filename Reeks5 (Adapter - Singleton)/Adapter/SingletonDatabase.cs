using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;

namespace Adapter
{
    public class SingletonDatabase : IDatabase
    {
        private static SingletonDatabase instance;
        private readonly IDatabase db;

        private SingletonDatabase()
        {
            db = new MySQLDatabase();
            db.OpenConnection();
        }

        ~SingletonDatabase()
        {
            db.CloseConnection();
        }

        public static IDatabase Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SingletonDatabase();
                }
                return instance;
            }
        }

        public void DeleteUser(User user)
        {
            db.DeleteUser(user);
        }

        public void InsertUser(User user)
        {
            db.InsertUser(user);
        }

        public List<User> SelectAllUsers()
        {
            return db.SelectAllUsers();
        }

        public void UpdateUser(User user)
        {
            db.UpdateUser(user);
        }

        public void CloseConnection()
        {
            //niets
        }

        public bool IsConnected
        {
            get
            {
                return db.IsConnected;
            }
        }

        public void OpenConnection()
        {
            //niets
        }
    }
}
