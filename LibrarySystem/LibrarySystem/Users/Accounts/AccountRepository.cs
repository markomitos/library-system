using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.Accounts
{
    public class AccountRepository
    {
        public const string AccountsFilePath = "..\\..\\..\\Users\\Accounts\\accounts.json";
        public List<Account> Accounts = new();

        public AccountRepository()
        {
            if (!File.Exists(AccountsFilePath)) return;

            string json = File.ReadAllText(AccountsFilePath);
            Accounts = JsonConvert.DeserializeObject<List<Account>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Accounts, Formatting.Indented);
            File.WriteAllText(AccountsFilePath, json);
        }

        public void Add(Account account)
        {
            Accounts.Add(account);
            Save();
        }

        public void Edit(Account account)
        {
            int index = Accounts.FindIndex(oldAccount => oldAccount.Username == account.Username);

            if (index == -1)
            {
                throw new ArgumentException("Account with username " + account.Username + " does not exist.");
            }
            Accounts[index] = account;
            Save();
        }

        public void Remove(Account account)
        {
            
            int index = Accounts.FindIndex(oldAccount => oldAccount.Username == account.Username);

            if (index == -1)
            {
                throw new ArgumentException("Account with username " + account.Username + " does not exist.");
            }
            Accounts.RemoveAt(index);
            Save();
        }

        public Account? Get(string username, string password)
        {
            return Accounts.FirstOrDefault(account => account.Username == username && account.Password == password);
        }

        public Account? Get(string username)
        {
            return Accounts.FirstOrDefault(account => account.Username == username);
        }

        public bool Contains(string username)
        {
            return Accounts.Any(account => account.Username == username);
        }

        
    }
}
