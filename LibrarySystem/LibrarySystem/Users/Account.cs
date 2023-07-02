using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users
{
    public class Account
    {
        public enum UserType
        {
            Librarian,
            SpecializedLibrarian,
            Member,
            Administrator
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
    }
}
