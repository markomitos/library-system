using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Add(Account account)
        {
            _accountRepository.Add(account);
        }

        public Account? GetAccount(string username, string password)
        {
            return _accountRepository.GetAccount(username, password);
        }
    }
}
