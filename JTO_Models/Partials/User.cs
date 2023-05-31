using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_Models
{
    public partial class User
    {
        public User(string userName, string password) { 
            UserName = userName;
            Password = password;
            Role = null;
        }

        public User() { }

        public override string ToString()
        {
            return UserName;
        }
    }
}
