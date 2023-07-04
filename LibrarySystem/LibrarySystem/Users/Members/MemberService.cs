using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Users.MemberRules;

namespace LibrarySystem.Users.Members
{
    public class MemberService
    {
        private MemberRepository _memberRepository;

       public MemberService(MemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void Add(Member member)
        {
            _memberRepository.Add(member);
        }

        public void Edit(Member member)
        {
            _memberRepository.Edit(member);
        }
        public void Remove(Member member)
        {
            _memberRepository.Remove(member);
        }
        public Member? Get(string jmbg)
        {
            return _memberRepository.Get(jmbg);
        }

        public bool AlreadyExistsJmbg(string jmbg)
        {
            return _memberRepository.Contains(jmbg);
        }

        public List<String> GetAllMembersJmbg()
        {
            return _memberRepository.GetAllMembersJmbg();
        }

        public ObservableCollection<Member> GetAll()
        {
            return _memberRepository.GetAll();
        }
        public Member? GetJMBG(string username)
        {
            return _memberRepository.GetJMBG(username);
        }

        public MemberRule.MemberType GetMemberType(string jmbg)
        {
            return _memberRepository.GetMemberType(jmbg);
        }
    }
}
