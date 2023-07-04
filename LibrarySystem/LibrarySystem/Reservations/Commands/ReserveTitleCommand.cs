using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView;
using System.Windows;
using LibrarySystem.Reservations.ViewModels;
using LibrarySystem.Utils;
using LibrarySystem.Reservations.Views;
using LibrarySystem.Users.Members;

namespace LibrarySystem.Reservations.Commands
{
    public class ReserveTitleCommand:CommandBase
    {
        ReserveTitleDialogViewModel _viewModel;
        TitleService _titleService = new(new TitleRepository());
        ReservationService _reservationService = new(new  ReservationRepository());
        MemberService _memberService = new(new MemberRepository());
        public ReserveTitleCommand(ReserveTitleDialogViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ReserveTitleDialogViewModel.SelectedTitle))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedTitle != null && base.CanExecute(parameter);
        }
        public override void Execute(object? Parameter)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Reservation confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Title title = _titleService.Get(_viewModel.SelectedTitle.UDK);
                _reservationService.Reserve(_viewModel.SelectedTitle.UDK, _memberService.GetJMBG(Globals.LoggedUser.Username).Jmbg);
                _viewModel._reserveTitleDialog.Close();
            }
        }
    }
}
