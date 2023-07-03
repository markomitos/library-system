using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Users.GUI.Commands;
using LibrarySystem.Users.Members;

namespace LibrarySystem.Users.GUI.ViewModels
{
    public class MembersHandlingViewModel
    {
        private readonly MemberService _memberService = new MemberService(new MemberRepository());
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

        public MembersHandlingViewModel()
        {
            LoadMembers();
        }

        public void LoadMembers()
        {
            Members = _memberService.GetAll();
        }
    }
}
