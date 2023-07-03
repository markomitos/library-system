using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs;
using LibrarySystem.NotificationDialogs.Presentation;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn.Commands
{
    public class ReturnBookCommand:CommandBase
    {
        private ReturnBookViewModel _viewModel;

        public ReturnBookCommand(ReturnBookViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            SuccessDialog successDialog = new SuccessDialog("Book successfully returned!");
            successDialog.ShowDialog();
        }

    }
}
