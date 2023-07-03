using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EditMemberCommand : CommandBase
    {
        private readonly EditMemberViewModel _editMemberViewModel;
        private readonly MemberService _memberService = new MemberService(new MemberRepository());
        private readonly AccountService _accountService = new AccountService(new AccountRepository());

        public EditMemberCommand(EditMemberViewModel editMemberViewModel)
        {
            _editMemberViewModel = editMemberViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                Member newMember = ParseMember();
                Account newAccount = parseAccount();
                _memberService.Edit(newMember);
                _accountService.Edit(newAccount);

                Notification.ShowSuccessDialog("Successfully edited member");

                _editMemberViewModel.EditMemberWindow.Close();
                _editMemberViewModel.ReloadParentWindow();
            }
            catch (Exception error)
            {
                Notification.ShowErrorDialog(error.Message);
            }
        }

        private Member ParseMember()
        {
            string jmbg = _editMemberViewModel.Jmbg;
            string firstName = _editMemberViewModel.FirstName;
            string lastName = _editMemberViewModel.LastName;
            string address = _editMemberViewModel.Address;
            string email = _editMemberViewModel.Email;
            string username = _editMemberViewModel.Username;
            string password = _editMemberViewModel.Password;
            string phone = _editMemberViewModel.Phone;
            bool isEmailWarning = _editMemberViewModel.IsEmailWarning;
            MemberRule.MemberType type = _editMemberViewModel.Type;

            return new Member(jmbg, firstName, lastName, address, phone, email, username, isEmailWarning, type);
        }

        private Account parseAccount()
        {
            string username = _editMemberViewModel.Username;
            string password = _editMemberViewModel.Password;

            return new Account(username, password, Account.UserType.Member);
        }
    }
}
