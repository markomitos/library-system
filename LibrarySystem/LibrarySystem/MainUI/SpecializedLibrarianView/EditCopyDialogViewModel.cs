using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging;
using LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView
{
    public class EditCopyDialogViewModel : ViewModelBase
    {
        public EditCopyDialog EditCopyDialog;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        private Copy _selectedCopy;
        public int Id;
        public EditCopyDialogViewModel(EditCopyDialog editCopyDialog, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            EditCopyDialog = editCopyDialog;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
            _selectedCopy = _specializedLibrarianViewModel.SelectedCopy;
            LoadData();
        }

        private void LoadData()
        {
            LoadStatuses();
            Id = _selectedCopy.Id;
            SelectedStatus = _selectedCopy.Status;
            IsChecked = _selectedCopy.IsDamaged;
            Price = _selectedCopy.Price;
        }

        private void LoadStatuses()
        {
            Statuses = new ObservableCollection<Copy.CopyStatus>
            {
                Copy.CopyStatus.Available,
                Copy.CopyStatus.Lost,
                Copy.CopyStatus.Rented,
                Copy.CopyStatus.Reserved
            };
        }

        private ObservableCollection<Copy.CopyStatus> _statuses;

        public ObservableCollection<Copy.CopyStatus> Statuses
        {
            get { return _statuses; }
            set
            {
                if (_statuses != value)
                {
                    _statuses = value;
                    OnPropertyChanged(nameof(Statuses));
                }
            }
        }

        private Copy.CopyStatus _selectedStatus;
        public Copy.CopyStatus SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                }
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        private ICommand _editCopyCommand;

        public ICommand EditCopyCommand
        {
            get { return _editCopyCommand ??= new EditCopyCommand(this, _specializedLibrarianViewModel); }
        }


    }
}
