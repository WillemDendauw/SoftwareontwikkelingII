using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyModel
{
    public class User
    {
        public User(string username, bool isAdmin = false)
        {
            UserName = username;
            IsAdmin = isAdmin;
        }

        public bool IsAdmin { get; }
        public string UserName { get; }
    }
}
