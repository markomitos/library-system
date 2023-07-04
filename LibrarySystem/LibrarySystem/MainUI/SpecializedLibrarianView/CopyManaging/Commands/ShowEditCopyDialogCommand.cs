using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands
{
    class ShowEditCopyDialogCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;
        public ShowEditCopyDialogCommand(SpecializedLibrarianViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SpecializedLibrarianViewModel.SelectedCopy))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedCopy != null && base.CanExecute(parameter);
        }
        public override void Execute(object? Parameter)
        {
            EditCopyDialog editCopydialog = new EditCopyDialog(_viewModel);
            editCopydialog.ShowDialog();

        }
    }
}
