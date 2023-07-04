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
        public bool IsEmailWarning { get; set; }
        public MemberRule.MemberType Type { get; set; }

        public Member(string jmbg, string firstName, string lastName, string address, string phone, string email, string username, bool isEmailWarning, MemberRule.MemberType type) : base(jmbg, firstName, lastName, address, phone, email, username)
        {
            ValidateParameters(type);
            this.IsEmailWarning = isEmailWarning;
            Type = type;
        }

        private void ValidateParameters(MemberRule.MemberType type)
        {
            if (type == null)
            {
                throw new ArgumentException("Member must have its type");
            }
        }
    }
}
