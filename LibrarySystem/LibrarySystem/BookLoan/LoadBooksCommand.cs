using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Users.Accounts;
using LibrarySystem.Utils;
using ZdravoCorp.MainUI.NotificationDialogs;

namespace LibrarySystem.BookLoan
{
    internal class LoadBooksCommand : CommandBase
    {
        private BookLoanViewModel _viewModel;
        private BookService _bookService; 

        public LoadBooksCommand(BookLoanViewModel viewModel)
        {
            _viewModel = viewModel;
            _bookService = new BookService(new BookRepository());
        }


        public override void Execute(object? parameter)
        {
            Console.WriteLine(_viewModel.SelectedTitle.Genre);
            _viewModel.Books = new ObservableCollection<Book>(_bookService.GetBooksByIsbn(_viewModel.SelectedTitle.Books));
        }


    }
}
