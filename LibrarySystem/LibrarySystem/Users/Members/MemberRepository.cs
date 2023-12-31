﻿using LibrarySystem.Users.Accounts;
using LibrarySystem.Users.Librarians;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Users.MemberRules;

namespace LibrarySystem.Users.Members
{
    public class MemberRepository
    {
        public const string MembersFilePath = "..\\..\\..\\Users\\Members\\members.json";
        public ObservableCollection<Member> Members = new();

        public MemberRepository()
        {
            if (!File.Exists(MembersFilePath)) return;

            string json = File.ReadAllText(MembersFilePath);

            Members = JsonConvert.DeserializeObject<ObservableCollection<Member>> (json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Members, Formatting.Indented);
            File.WriteAllText(MembersFilePath, json);
        }

        public void Add(Member member)
        {
            Members.Add(member);
            Save();
        }

        public void Edit(Member member)
        {
            var found = Members.FirstOrDefault(oldMember => oldMember.Jmbg == member.Jmbg);
            int i = Members.IndexOf(found);
            Members[i] = member;
            Save();
        }

        public void Remove(Member member)
        {
            var found = Members.FirstOrDefault(oldMember => oldMember.Jmbg == member.Jmbg);
            int i = Members.IndexOf(found);
            Members.RemoveAt(i);
            Save();
        }
        public Member? Get(string jmbg)
        {
            return Members.FirstOrDefault(member => member.Jmbg == jmbg);
        }

        public bool Contains(string jmbg)
        {
            return Members.Any(librarian => librarian.Jmbg == jmbg);
        }

        public List<String> GetAllMembersJmbg()
        {
            return Members.Select(member => member.Jmbg).ToList();
        }

        public ObservableCollection<Member> GetAll()
        {
            return Members;
        }
        public Member? GetJMBG(string username)
        {
            return Members.FirstOrDefault(member => member.Username == username);
        }

        public MemberRule.MemberType GetMemberType(string jmbg)
        {
            return Get(jmbg).Type;
        }
    }
}
