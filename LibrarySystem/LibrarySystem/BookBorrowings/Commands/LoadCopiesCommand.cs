using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LibrarySystem.BookBorrowings.ViewModel;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.Commands
{
    internal class LoadCopiesCommand : CommandBase
    {
        private BookBorrowingViewModel _viewModel;
        private CopiesService _copiesService;
        private BookService _bookService;

        public LoadCopiesCommand(BookBorrowingViewModel viewModel)
        {
            _viewModel = viewModel;
            _copiesService = new CopiesService(new CopiesRepository());
            _bookService = new BookService(new BookRepository());
        }

        public override void Execute(object? parameter)
        {
            try
            {
                Book book = _bookService.Get(_viewModel.SelectedBook.ISBN);
                List<Copy> copies = _copiesService.GetCopiesById(book.Copies);

                if (copies.Count == 0) throw new Exception("There are no copies for chosen book! ");
                _viewModel.Copies = new ObservableCollection<Copy>(copies);
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
                _viewModel.Copies = new ObservableCollection<Copy>(new List<Copy>());
            }

        }

    }
}
