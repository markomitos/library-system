using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.MainUI.Commands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.ViewModels
{
    internal class MemberWindowViewModel : ViewModelBase
    {
        private string? _loggedUser;

        public string? LoggedUser
        {
            get => _loggedUser;
            set
            {
                _loggedUser = value;
                OnPropertyChanged(nameof(LoggedUser));
            }
        }

        private ICommand? _logoutCommand { get; set; }

        public ICommand LogoutCommand
        {
            get
            {
                return _logoutCommand ??= new LogoutCommand(_memberWindow);
            }
        }

        private ICommand? _cancelReservationCommand { get; set; }

        public ICommand CancelReservationCommand
        {
            get
            {
                return _cancelReservationCommand ??= new OpenCancelReservationViewCommand(_memberWindow);
            }
        }

        private readonly MemberWindow _memberWindow;
        
        public MemberWindowViewModel(MemberWindow memberWindow)
        {
            _memberWindow = memberWindow;
            LoggedUser = Globals.LoggedUser!.Username;
        }
    }
}
