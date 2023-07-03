using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Users.Accounts;
using LibrarySystem.Users.GUI.ViewModels;
using LibrarySystem.Users.GUI.Views;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.Users.GUI.Commands
{
    public class RemoveSelectedMemberCommand : CommandBase
    {
        private MembersHandlingViewModel _membersHandlingViewModel;
        private readonly MemberService _memberService = new MemberService(new MemberRepository());
        private readonly AccountService _accountService = new AccountService(new AccountRepository());
        public RemoveSelectedMemberCommand(MembersHandlingViewModel membersHandlingViewModel)
        {
            _membersHandlingViewModel = membersHandlingViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                if (_membersHandlingViewModel.SelectedMember == null)
                {
                    throw new InvalidOperationException("Member must be selected");
                }

                _memberService.Remove(_membersHandlingViewModel.SelectedMember);
                _accountService.Remove(_accountService.Get(_membersHandlingViewModel.SelectedMember.Username));

                Notification.ShowSuccessDialog("Successfully deleted member with username " + _membersHandlingViewModel.SelectedMember.Username);

                _membersHandlingViewModel.ReloadWindow();
            }
            catch (Exception error)
            {
                Notification.ShowErrorDialog(error.Message);
            }
        }
    }
}
