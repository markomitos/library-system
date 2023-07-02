using LibrarySystem.Users.Librarians;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.MemberRules
{
    public class MemberRuleRepository
    {
        public const string MemberRulesFilePath = "..\\..\\..\\Users\\MemberRules\\member_rules.json";
        public List<MemberRule> MemberRules = new();

        public MemberRuleRepository()
        {
            if (!File.Exists(MemberRulesFilePath)) return;

            string json = File.ReadAllText(MemberRulesFilePath);
            MemberRules = JsonConvert.DeserializeObject<List<MemberRule>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(MemberRules, Formatting.Indented);
            File.WriteAllText(MemberRulesFilePath, json);
        }

        public void Add(MemberRule memberRule)
        {
            MemberRules.Add(memberRule);
            Save();
        }

        public MemberRule? Get(MemberRule.MemberType type)
        {
            return MemberRules.FirstOrDefault(memberRule => memberRule.Type == type);
        }

    }
}
