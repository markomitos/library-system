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
            ValidateParameters(jmbg, firstName, lastName, address, phone, email, username);
            Jmbg = jmbg;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
            Username = username;
        }

        private void ValidateParameters(string jmbg, string firstName, string lastName, string address, string phone,
            string email, string username)
        {
            if (jmbg.Length != 13)
            {
                throw new ArgumentException("Jmbg must be 13 numbers");
            }
            else if (jmbg == null || firstName == null || lastName == null || address == null || phone == null || email == null || username == null)
            {
                throw new ArgumentException("User must have all information");
            }
            else if (firstName.Length == 0 || lastName.Length == 0 || address.Length == 0 || phone.Length == 0 || email.Length == 0 || username.Length == 0)
            {
                throw new ArgumentException("User must have all information");
            }
        }

    }
}
