using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.MemberRules
{
    public class MemberRuleService
    {
        private readonly MemberRuleRepository _memberRuleRepository;

        MemberRuleService(MemberRuleRepository memberRuleRepository)
        {
            _memberRuleRepository = memberRuleRepository;
        }

        public void Add(MemberRule memberRule)
        {
            _memberRuleRepository.Add(memberRule);
        }

        public MemberRule? Get(MemberRule.MemberType type)
        {
            return _memberRuleRepository.Get(type);
        }
    }
}
