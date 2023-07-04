using LibrarySystem.Users.MemberRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.Librarians
{
    public class Librarian : User
    {
        public string BranchName { get; set; }

        public Librarian(string jmbg, string firstName, string lastName, string address, string phone, string email, string username, string branchName) : base(jmbg, firstName, lastName, address, phone, email, username)
        {
            BranchName = branchName;
        }
    }
}
