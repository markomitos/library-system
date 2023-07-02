using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Users.GUI.ViewModels;
using LibrarySystem.Users.MemberRules;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;
using ZdravoCorp.MainUI.NotificationDialogs;

namespace LibrarySystem.Users.GUI.Commands
{
    class RegisterMemberCommand : CommandBase
    {
        private RegisterMemberViewModel _registerMemberViewModel;
        public RegisterMemberCommand(RegisterMemberViewModel registerMemberViewModel)
        {
            _registerMemberViewModel = registerMemberViewModel;
        }

        public override void Execute(object? parameter)
        {
            Member newMember = ParseMember();
            Notification.ShowSuccessDialog("Successfull");
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
            //MemberRule.MemberType type = (MemberRule.MemberType)Enum.Parse(typeof(MemberRule.MemberType), _registerMemberViewModel.Type);
            MemberRule.MemberType type = _registerMemberViewModel.Type;

            return new Member(jmbg, firstName, lastName, address, phone, email, username, isEmailWarning, type);
        }
    }
}
