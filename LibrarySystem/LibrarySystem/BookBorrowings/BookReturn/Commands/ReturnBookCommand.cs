using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.NotificationDialogs.Presentation;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn.Commands
{
    public class ReturnBookCommand:CommandBase
    {
        private ReturnBookViewModel _viewModel;
        private BookBorrowingService _bookBorrowingService;

        public ReturnBookCommand(ReturnBookViewModel viewModel,BookBorrowingService bookBorrowingService)
        {
            _viewModel = viewModel;
            _bookBorrowingService = bookBorrowingService;
        }

        public override void Execute(object? parameter)
        {
            _bookBorrowingService.ReturnBook(_viewModel.Borrowing);
            _viewModel.RefreshData();
        }

    }
}
