using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Users.MemberRules;

namespace LibrarySystem.Users.Members
{
    public class Member : User
    {
        public bool isEmailWarning { get; set; }
        public MemberRule.MemberType Type { get; set; }

        public Member(string jmbg, string firstName, string lastName, string adress, string phone, string email, string username, bool isEmailWarning, MemberRule.MemberType type) : base(jmbg, firstName, lastName, adress, phone, email, username)
        {
            this.isEmailWarning = isEmailWarning;
            Type = type;
        }
    }
}
