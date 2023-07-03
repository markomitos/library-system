using LibrarySystem.Users.GUI.Commands;
using LibrarySystem.Users.GUI.Views;
using LibrarySystem.Users.MemberRules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibrarySystem.Users.MemberRules.MemberRule;
using System.Windows.Input;
using LibrarySystem.Users.Accounts;
using LibrarySystem.Users.Members;

namespace LibrarySystem.Users.GUI.ViewModels
{
    public class EditMemberViewModel
    {
        private readonly AccountService _accountService = new(new AccountRepository());

        public readonly MembersHandlingWindow MembersHandlingWindow;
        public readonly EditMemberWindow EditMemberWindow;
        public readonly Member EditedMember;
        public readonly Account EditedAccount;

        public ObservableCollection<MemberType> AvailableMemberTypes { get; set; }

        public string Jmbg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsEmailWarning { get; set; }
        public MemberRule.MemberType Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        


        private ICommand _editMemberCommand;
        public ICommand EditMemberCommand
        {
            get { return _editMemberCommand ??= new EditMemberCommand(this); }
        }


        public EditMemberViewModel(MembersHandlingWindow? membersHandlingWindow, EditMemberWindow editMemberWindow, Member editedMember)
        {
            MembersHandlingWindow = membersHandlingWindow;
            EditMemberWindow = editMemberWindow;
            EditedMember = editedMember;
            EditedAccount = _accountService.Get(EditedMember.Username);

            fillMemberTypeComboBox();
            fillFields();
        }

        private void fillMemberTypeComboBox()
        {
            List<MemberType> memberTypes = new List<MemberType>(Enum.GetValues(typeof(MemberType)) as MemberType[]);

            AvailableMemberTypes = new ObservableCollection<MemberType>(memberTypes);

        }

        private void fillFields()
        {
            Jmbg = EditedMember.Jmbg;
            FirstName = EditedMember.FirstName;
            LastName = EditedMember.LastName;
            Address = EditedMember.Address;
            Phone = EditedMember.Phone;
            Email = EditedMember.Email;
            IsEmailWarning = EditedMember.IsEmailWarning;
            Type = EditedMember.Type;
            Username = EditedAccount.Username;
            Password = EditedAccount.Password;
        }


        public void ReloadParentWindow()
        {
            MembersHandlingWindow.Close();
            MembersHandlingWindow newMembersHandlingWindow = new();
            newMembersHandlingWindow.ShowDialog();
        }
    }
}

