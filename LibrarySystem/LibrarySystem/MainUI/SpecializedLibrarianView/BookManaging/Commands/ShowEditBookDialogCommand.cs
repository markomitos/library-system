using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging;
using LibrarySystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands
{
    class ShowEditBookDialogCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;
        private BookService _bookService= new(new BookRepository());
        public ShowEditBookDialogCommand(SpecializedLibrarianViewModel viewModel)
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
            EditBookDialog editBookdialog = new EditBookDialog(_viewModel);
            editBookdialog.ShowDialog();

        }
    }
}
