using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.MainUI;
using LibrarySystem.MainUI.ViewModels;
using LibrarySystem.Utils;

namespace LibrarySystem.Reservations.Commands
{
    internal class CancelReservationCommand : CommandBase
    {
        private ReservationService _reservationService;
        private CancelReservationView _cancelReservationView;
        private readonly CancelReservationViewModel _cancelReservationViewModel;
        public CancelReservationCommand(CancelReservationView cancelReservationView, CancelReservationViewModel cancelReservationViewModel)
        {
            
            _cancelReservationView = cancelReservationView;
            _cancelReservationViewModel = cancelReservationViewModel;
            _cancelReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CancelReservationViewModel.SelectedReservation))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            _reservationService = new ReservationService(new ReservationRepository());
            Reservation reservation = _cancelReservationViewModel.SelectedReservation!;

            if (reservation.State == Reservation.ReservationState.Approved)
            {
                CancelApprovedReservation(reservation);
            }else{
                CancelNotApprovedReservations(reservation);
            }
        }

        private void CancelNotApprovedReservations(Reservation reservation)
        {
            Reservation reservationToChange = _reservationService.Get(reservation.Id)!;
            reservationToChange.State = Reservation.ReservationState.Canceled;
            _reservationService.Save();
            ReloadCancelReservationView();
        }

        private void ReloadCancelReservationView()
        {

            CancelReservationView newCancelReservationView = new CancelReservationView();
            newCancelReservationView.Show();

            _cancelReservationView.Close();
        }

        private void CancelApprovedReservation(Reservation reservation)
        {

            _reservationService.ApproveNextInQueueForBook(reservation.TitleUDK, reservation.CopyId);

            Reservation reservationToChange = _reservationService.Get(reservation.Id)!;
            reservationToChange.State = Reservation.ReservationState.Canceled;
            _reservationService.Save();
            ReloadCancelReservationView();
        }

        public override bool CanExecute(object? parameter)
        {
            return _cancelReservationViewModel.SelectedReservation != null && base.CanExecute(parameter);
        }
    }
}
