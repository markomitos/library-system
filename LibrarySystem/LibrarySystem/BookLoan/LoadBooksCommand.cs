﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Users.Accounts;
using LibrarySystem.Utils;

namespace LibrarySystem.BookLoan
{
    internal class LoadBooksCommand : CommandBase
    {
        private BookBorrowingViewModel _viewModel;
        private BookService _bookService; 

        public LoadBooksCommand(BookBorrowingViewModel viewModel)
        {
            _viewModel = viewModel;
            _bookService = new BookService(new BookRepository());
        }


        public override void Execute(object? parameter)
        {
            try
            {
                List<Book> books = _bookService.GetBooksByIsbn(_viewModel.SelectedTitle.Books);

                if (books.Count == 0) throw new Exception("There are no books for chosen title! ");
                _viewModel.Books = new ObservableCollection<Book>(books);
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
                _viewModel.Books = new ObservableCollection<Book>(new List<Book>());
            }
            
        }


    }
}
