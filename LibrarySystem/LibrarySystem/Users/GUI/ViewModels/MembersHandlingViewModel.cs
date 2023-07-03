using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Users.GUI.Commands;
using LibrarySystem.Users.GUI.Views;
using LibrarySystem.Users.Members;

namespace LibrarySystem.Users.GUI.ViewModels
{
    public class MembersHandlingViewModel
    {
        private readonly MemberService _memberService = new MemberService(new MemberRepository());

        private MembersHandlingWindow _membersHandlingWindow;
        public ObservableCollection<Member> Members { get; set; }

        public Member? SelectedMember { get; set; }

        private ICommand _showRegisterMemberWindowCommand;
        public ICommand ShowRegisterMemberWindowCommand
        {
            get { return _showRegisterMemberWindowCommand ??= new ShowRegisterMemberWindowCommand(); }
        }

        private ICommand _showEditMemberWindowCommand;
        public ICommand ShowEditMemberWindowCommand
        {
            get { return _showEditMemberWindowCommand ??= new ShowEditMemberWindowCommand(this); }
        }

        private ICommand _removeSelectedMemberCommand;
        public ICommand RemoveSelectedMemberCommand
        {
            get { return _removeSelectedMemberCommand ??= new RemoveSelectedMemberCommand(this); }
        }

        public MembersHandlingViewModel(MembersHandlingWindow membersHandlingWindow)
        {
            _membersHandlingWindow = membersHandlingWindow;
            LoadMembers();
        }

        public void LoadMembers()
        {
            Members = _memberService.GetAll();
        }

        public void ReloadWindow()
        {
            _membersHandlingWindow.Close();
            MembersHandlingWindow newMembersHandlingWindow = new();
            newMembersHandlingWindow.ShowDialog();
        }
    }
}
