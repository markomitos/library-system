using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn
{
    public class LoadUserBorrowingsCommand:CommandBase
    {
        private BookReturnViewModel _viewModel;
        private BookBorrowingService _borrowingService;

        public LoadUserBorrowingsCommand(BookReturnViewModel viewModel)
        {
            _viewModel = viewModel;
            _borrowingService = new BookBorrowingService(new BookBorrowingRepository());
        }

        public override void Execute(object? parameter)
        {
            _viewModel.Borrowings = _borrowingService.GetAll(parameter.ToString());
        }
    }
}
