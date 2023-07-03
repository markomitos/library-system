using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.MemberRules
{
    public class MemberRule
    {
        public enum MemberType
        {
            Child,
            Pupil,
            Student,
            Employer,
            Pensioner
        }

        public MemberType Type { get; set; }

        public int MembershipFee { get; set; }
        public int MaxRentDays { get; set; }
        public int MaxCopies { get; set; }

        public MemberRule(MemberType type, int membershipFee, int maxRentDays, int maxCopies)
        {
            Type = type;
            MembershipFee = membershipFee;
            MaxRentDays = maxRentDays;
            MaxCopies = maxCopies;
        }
    }
}
