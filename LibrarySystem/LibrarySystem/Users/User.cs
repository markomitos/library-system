using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users
{
    public class User
    {
        public string Jmbg { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public User(string jmbg, string firstName, string lastName, string address, string phone, string email, string username)
        {
            Jmbg = jmbg;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
            Username = username;
        }

    }
}
