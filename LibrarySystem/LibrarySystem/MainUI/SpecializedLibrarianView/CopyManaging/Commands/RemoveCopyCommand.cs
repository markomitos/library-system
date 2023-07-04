using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands
{
    class RemoveCopyCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;
        CopiesService _copiesService = new(new CopiesRepository());
        BookService _bookService = new(new BookRepository());
        public RemoveCopyCommand(SpecializedLibrarianViewModel viewModel)
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
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Copy copy = _viewModel.SelectedCopy;
                _bookService.RemoveCopy(_viewModel.SelectedBook.ISBN, copy.Id);
                SpecializedLibrarianWindow window = new();
                window.Show();
                _viewModel._SpecializedLibrarianWindow.Close();
            }
        }
    }
}
