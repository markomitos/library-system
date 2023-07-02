using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Users.Accounts;
using LibrarySystem.Users.GUI.ViewModels;
using LibrarySystem.Users.MemberRules;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.Users.GUI.Commands
{
    class RegisterMemberCommand : CommandBase
    {
        private readonly RegisterMemberViewModel _registerMemberViewModel;
        private readonly MemberService _memberService = new MemberService(new MemberRepository());
        private readonly AccountService _accountService = new AccountService(new AccountRepository());
        public RegisterMemberCommand(RegisterMemberViewModel registerMemberViewModel)
        {
            _registerMemberViewModel = registerMemberViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                Member newMember = ParseMember();
                Account newAccount = parseAccount();
                _memberService.Add(newMember);
                _accountService.Add(newAccount);

                Notification.ShowSuccessDialog("Successfully registered new member");

                _registerMemberViewModel.RegisterMemberWindow.Close();
                _registerMemberViewModel.ReloadParentWindow();
            }
            catch (Exception error)
            {
                Notification.ShowErrorDialog(error.Message);
            }
        }

        private Member ParseMember()
        {
            string jmbg = _registerMemberViewModel.Jmbg;
            string firstName = _registerMemberViewModel.FirstName;
            string lastName = _registerMemberViewModel.LastName;
            string address = _registerMemberViewModel.Address;
            string email = _registerMemberViewModel.Email;
            string username = _registerMemberViewModel.Username;
            string password = _registerMemberViewModel.Password;
            string phone = _registerMemberViewModel.Phone;
            bool isEmailWarning = _registerMemberViewModel.IsEmailWarning;
            MemberRule.MemberType type = _registerMemberViewModel.Type;

            if (_memberService.AlreadyExistsJmbg(jmbg))
            {
                throw new ArgumentException("This jmbg already exists");
            }

            return new Member(jmbg, firstName, lastName, address, phone, email, username, isEmailWarning, type);
        }

        private Account parseAccount()
        {
            string username = _registerMemberViewModel.Username;
            string password = _registerMemberViewModel.Password;

            if (_accountService.AlreadyExistsUsername(username))
            {
                throw new ArgumentException("This username already exists");
            }

            return new Account(username, password, Account.UserType.Member);
        }
    }
}
