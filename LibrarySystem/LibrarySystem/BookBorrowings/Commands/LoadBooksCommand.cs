using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using LibrarySystem.BookBorrowings.ViewModel;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.Commands
{
    internal class LoadBooksCommand : CommandBase
    {
        private BookBorrowingViewModel _viewModel;
        private BookService _bookService;
        private TitleService _titleService;

        public LoadBooksCommand(BookBorrowingViewModel viewModel)
        {
            _viewModel = viewModel;
            _bookService = new BookService(new BookRepository());
            _titleService = new TitleService(new TitleRepository());
        }


        public override void Execute(object? parameter)
        {
            try
            {
                Title title = _titleService.Get(_viewModel.SelectedTitle.UDK);
                List<Book> books = _bookService.GetBooksByIsbn(title.Books);

                if (books.Count == 0) throw new Exception("There are no books for chosen title! ");

                _viewModel.LoadBooks(books);
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }
            
        }


    }
}
