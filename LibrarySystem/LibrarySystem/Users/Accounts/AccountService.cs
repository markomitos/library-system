using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.Accounts
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

        public void Edit(Account account)
        {
            _accountRepository.Edit(account);
        }
        public void Remove(Account account)
        {
            _accountRepository.Remove(account);
        }

        public Account? Get(string username, string password)
        {
            return _accountRepository.Get(username, password);
        }

        public Account? Get(string username)
        {
            return _accountRepository.Get(username);
        }

        public bool AlreadyExistsUsername(string username)
        {
            return _accountRepository.Contains(username);
        }
    }
}
