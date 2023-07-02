using LibrarySystem.Users.Librarians;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.Members
{
    public class MemberRepository
    {
        public const string MembersFilePath = "..\\..\\..\\Users\\Members\\members.json";
        public List<Member> Members = new();

        public MemberRepository()
        {
            if (!File.Exists(MembersFilePath)) return;

            string json = File.ReadAllText(MembersFilePath);
            Members = JsonConvert.DeserializeObject<List<Member>>(json);
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

        public Member? Get(string jmbg)
        {
            return Members.FirstOrDefault(member => member.Jmbg == jmbg);
        }

        public bool Contains(string jmbg)
        {
            return Members.Any(librarian => librarian.Jmbg == jmbg);
        }

        public Member? GetJMBG(string username)
        {
            return Members.FirstOrDefault(member => member.Username == username);
        }
    }
}
