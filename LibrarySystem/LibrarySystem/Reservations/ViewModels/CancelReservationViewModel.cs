using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Reservations;
using LibrarySystem.Reservations.Commands;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.ViewModels
{
    internal class CancelReservationViewModel : ViewModelBase
    {
        private ReservationService _reservationService;
        private MemberService _memberService;

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
        private Reservation? _selectedReservation;

        public Reservation? SelectedReservation
        {
            get => _selectedReservation;
            set
            {
                _selectedReservation = value;
                OnPropertyChanged(nameof(SelectedReservation));
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
        private ICommand? _cancelReservationCommand { get; set; }

        public ICommand CancelReservationCommand
        {
            get
            {
                return _cancelReservationCommand ??= new CancelReservationCommand(_cancelReservationView, this);
            }
        }

        private ObservableCollection<Reservation>? _reservations;
        public ObservableCollection<Reservation>? Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        private readonly CancelReservationView _cancelReservationView;
        
        public CancelReservationViewModel(CancelReservationView cancelReservationView)
        {
            _reservationService = new ReservationService(new ReservationRepository());
            _memberService = new MemberService(new MemberRepository());
            _cancelReservationView = cancelReservationView;
            LoggedUser = Globals.LoggedUser!.Username;
            LoadReservationsDataGrid();
        }

        private void LoadReservationsDataGrid()
        {
            var loggedUser = _memberService.GetJMBG(LoggedUser)?.Jmbg;
            if (loggedUser != null)
            {
                Reservations = _reservationService.GetNotFinishedReservations(loggedUser);
            }
            else
            {
                Notification.ShowErrorDialog("That member doesn't exist anymore!");
            }
        }
    }
}
