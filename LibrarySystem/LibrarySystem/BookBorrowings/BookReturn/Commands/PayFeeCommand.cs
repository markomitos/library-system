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
    public class PayFeeCommand:CommandBase
    {
        private ReturnBookViewModel _viewModel;

        public PayFeeCommand(ReturnBookViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            SuccessDialog successDialog = new SuccessDialog("Fee successfully payed!");
            successDialog.ShowDialog();
            HideFeeElements();
        }

        private void HideFeeElements()
        {
            _viewModel.IsFeePayed = true;
            _viewModel.ShowFeeButton = false;
            _viewModel.Fee = "";
        }
    }
}
