using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Users.GUI.Commands;
using LibrarySystem.Users.GUI.Views;
using LibrarySystem.Users.MemberRules;
using static LibrarySystem.Users.MemberRules.MemberRule;

namespace LibrarySystem.Users.GUI.ViewModels
{
    public class RegisterMemberViewModel
    {
        private readonly MembersHandlingWindow _membersHandlingWindow;

        public ObservableCollection<MemberType> AvailableMemberTypes { get; set; }

        public string Jmbg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsEmailWarning { get; set; }
        public MemberRule.MemberType Type { get; set; }


        private ICommand _registerMemberCommand;
        public ICommand RegisterMemberCommand
        {
            get { return _registerMemberCommand ??= new RegisterMemberCommand(this); }
        }


        public RegisterMemberViewModel(MembersHandlingWindow? membersHandlingWindow)
        {
            _membersHandlingWindow = membersHandlingWindow;

            fillMemberTypeComboBox();
        }

        private void fillMemberTypeComboBox()
        {
            List<MemberType> memberTypes = new List<MemberType>(Enum.GetValues(typeof(MemberType)) as MemberType[]);

            AvailableMemberTypes = new ObservableCollection<MemberType>(memberTypes);

        }


        public void ReloadParentWindow()
        {
            MembersHandlingWindow newMembersHandlingWindow = new();
            newMembersHandlingWindow.ShowDialog();
            _membersHandlingWindow.Close();
        }
    }
}
