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
            throw new NotImplementedException();
        }
        public override bool CanExecute(object? parameter)
        {
            return _cancelReservationViewModel.SelectedReservation != null && base.CanExecute(parameter);
        }
    }
}
