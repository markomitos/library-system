using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn.Commands
{
    public class ShowReturnBookDialogCommand : CommandBase
    {
        private BookReturnViewModel _viewModel;
        private BookBorrowingService _bookBorrowingService = new BookBorrowingService(new BookBorrowingRepository());

        public ShowReturnBookDialogCommand(BookReturnViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            ReturnBookDialog returnBookDialog = new ReturnBookDialog(_viewModel.SelectedBorrowing);
            returnBookDialog.ShowDialog();
        }
    }
}

