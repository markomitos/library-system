using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Reservations.Commands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.ViewModels
{
    internal class CancelReservationViewModel : ViewModelBase
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
                return _logoutCommand ??= new LogoutCommand(_cancelReservationView);
            }
        }
        private ICommand? _backCommand { get; set; }

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ??= new BackToMemberWindowCommand(_cancelReservationView);
            }
        }

        private readonly CancelReservationView _cancelReservationView;
        
        public CancelReservationViewModel(CancelReservationView cancelReservationView)
        {
            _cancelReservationView = cancelReservationView;
            LoggedUser = Globals.LoggedUser!.Username;
        }
    }
}
