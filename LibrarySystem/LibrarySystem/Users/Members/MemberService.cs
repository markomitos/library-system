﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Member? Get(string jmbg)
        {
            return _memberRepository.Get(jmbg);
        }

        public ObservableCollection<Member> GetAll()
        {
            return _memberRepository.GetAll();
        }
    }
}
