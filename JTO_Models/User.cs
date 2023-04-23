using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }

        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Role = null;
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}
