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

        private ICommand _showRegisterMemberWindowCommand;

        public ICommand ShowRegisterMemberWindowCommand
        {
            get { return _showRegisterMemberWindowCommand ??= new ShowRegisterMemberWindowCommand(); }
        }

        public MembersHandlingViewModel()
        {
            LoadMembers();
        }

        public void LoadMembers()
        {
            Members = new ObservableCollection<Member>(_memberService.GetAllMembers());
        }
    }
}
