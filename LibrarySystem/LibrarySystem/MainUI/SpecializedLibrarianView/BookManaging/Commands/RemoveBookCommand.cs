using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands
{
    class RemoveBookCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;
        BookService _bookService = new(new BookRepository());
        public RemoveBookCommand(SpecializedLibrarianViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SpecializedLibrarianViewModel.SelectedBook))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedBook != null && base.CanExecute(parameter);
        }
        public override void Execute(object? Parameter)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Book book = _bookService.Get(_viewModel.SelectedBook.ISBN);
                _bookService.Remove(book.ISBN);
                SpecializedLibrarianWindow window = new();
                window.Show();
                _viewModel._SpecializedLibrarianWindow.Close();
            }
        }
    }
}
