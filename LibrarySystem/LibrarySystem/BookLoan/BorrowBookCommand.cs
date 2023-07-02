using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.MainUI;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.BookLoan
{
    internal class BorrowBookCommand : CommandBase
    {
        private BookBorrowingViewModel _viewModel;
        private BookBorrowingService _bookBorrowingService;
        private CopiesService _copiesService;
        private BookBorrowingView _bookBorrowingView;

        public BorrowBookCommand(BookBorrowingViewModel viewModel,BookBorrowingView bookBorrowingView)
        {
            _viewModel = viewModel;
            _bookBorrowingService = new BookBorrowingService(new BookBorrowingRepository());
            _copiesService = new CopiesService(new CopiesRepository());
            _bookBorrowingView = bookBorrowingView;
        }


        public override void Execute(object? parameter)
        {
            try
            {
                if (string.IsNullOrEmpty(_viewModel.SelectedMember)) throw new Exception("Please choose member! ");
                if (_viewModel.ReturnDate == null || _viewModel.ReturnDate <= DateTime.Now) throw new Exception("Please insert correct date! ");
                if (_viewModel.SelectedCopy == null) throw new Exception("Please select copy to borrow! ");
                if (_viewModel.SelectedCopy.Status != Copy.CopyStatus.Available) throw new Exception("You cant borrow this copy! ");

                _bookBorrowingService.CreateBookBorrowing(_viewModel.ReturnDate,DateTime.Now, false,false,_viewModel.SelectedCopy.Id,_viewModel.SelectedMember);
                _copiesService.BorrowCopy(_viewModel.SelectedCopy.Id);
                Notification.ShowSuccessDialog($"Successfully borrowed a book to {_viewModel.SelectedMember}");
                _bookBorrowingView.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }

        }

    }
}
