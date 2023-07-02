using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging
{
    class ShowAddBookDialogCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;
        public ShowAddBookDialogCommand(SpecializedLibrarianViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SpecializedLibrarianViewModel.SelectedTitle))
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
            AddBookDialog addBookDialog = new(_viewModel);
            addBookDialog.ShowDialog();
        }
    }
}
