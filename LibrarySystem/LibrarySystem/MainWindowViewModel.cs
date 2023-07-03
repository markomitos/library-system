using LibrarySystem.MainUI;
using LibrarySystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using LibrarySystem.MainCommands;
using LibrarySystem.MainUI.SpecializedLibrarianView;
using LibrarySystem.Utils;
using LibrarySystem.Reservations;
using LibrarySystem.Users.Accounts;
using LibrarySystem.Utils;


namespace LibrarySystem
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ReservationService _reservationService;
        private readonly MainWindow _mainWindow;

        private string? _username;

        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private ICommand? _logIn { get; set; }

        public ICommand LogIn
        {
            get
            {
                return _logIn ??= new LogInCommand(this, _mainWindow);
            }
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            _reservationService = new ReservationService(new ReservationRepository());
            _mainWindow = mainWindow;
            _reservationService.CancelExpiredReservations();
        }

    }
}
