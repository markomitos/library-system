using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.Accounts
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

        public Account(string username, string password, UserType type)
        {
            ValidateParameters(username, password, type);
            Username = username;
            Password = password;
            Type = type;
        }

        private void ValidateParameters(string username, string password, UserType type)
        {
            if (username == null || password == null || type == null || username.Length == 0 || password.Length == 0)
            {
                throw new ArgumentException("Account must have all information");
            }
        }
    }
}
