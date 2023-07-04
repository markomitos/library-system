using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.NotificationDialogs.Presentation;
using LibrarySystem.Payments;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn.Commands
{
    public class ReportDamageCommand:CommandBase
    {
        private ReturnBookViewModel _viewModel;
        private CopiesService _copiesService;
        private BookBorrowingService _borrowingService;
        public ReportDamageCommand(ReturnBookViewModel viewModel, BookBorrowingService borrowingService,CopiesService copiesService)
        {
            _viewModel = viewModel;
            _borrowingService = borrowingService;
            _copiesService = copiesService;
            _borrowingService.SetCopiesService(copiesService);
        }

        public override void Execute(object? parameter)
        {
            _copiesService.ReportDamagedCopy(_viewModel.Copy.Id);
            _viewModel.FeeAmount = _borrowingService.CalculateFee(_viewModel.Borrowing);
            ShowFeeElements();
        }

        private void ShowFeeElements()
        {
            _viewModel.IsFeePayed = false;
            _viewModel.ShowFeeButton = true;
            _viewModel.Fee = "Fee:  "+_viewModel.FeeAmount;
        }
    }
}
