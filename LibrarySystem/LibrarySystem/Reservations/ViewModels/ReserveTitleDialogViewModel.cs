using LibrarySystem.BookBorrowings.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using LibrarySystem.Utils;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Reservations.Commands;
using LibrarySystem.Reservations.Views;

namespace LibrarySystem.Reservations.ViewModels
{
    public class ReserveTitleDialogViewModel:ViewModelBase
    {
        private TitleViewModel? _selectedTitle;

        public TitleViewModel? SelectedTitle
        {
            get => _selectedTitle;
            set
            {
                _selectedTitle = value;
                OnPropertyChanged(nameof(SelectedTitle));
            }
        }

        public ObservableCollection<TitleViewModel> Titles { get; set; }

        private TitleService _titleService;
        public ReserveTitleDialog _reserveTitleDialog;

        private ICommand _reserveTitleCommand;

        public ICommand ReserveTitleCommand
        {
            get
            {
                return _reserveTitleCommand ??= new ReserveTitleCommand(this);
            }
        }

        public ReserveTitleDialogViewModel(ReserveTitleDialog reserveTitleDialog,TitleService titleService)
        {
            _reserveTitleDialog = reserveTitleDialog;
            _titleService = titleService;
            LoadTitles();
        }

        private void LoadTitles()
        {
            List<TitleViewModel> titleViewModels = new();
            foreach (Title title in _titleService.GetAll())
            {
                titleViewModels.Add(new TitleViewModel(title.Name, title.Language, title.UDK, title.Genre, title.Authors));
            }
            Titles = new ObservableCollection<TitleViewModel>(titleViewModels);
        }

    }
}
