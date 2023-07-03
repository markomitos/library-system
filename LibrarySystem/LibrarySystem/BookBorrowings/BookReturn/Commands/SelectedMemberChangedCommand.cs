using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn.Commands
{
    public class SelectedMemberChangedCommand : CommandBase
    {
        private BookReturnViewModel _viewModel;
        private BookBorrowingService _borrowingService;

        public SelectedMemberChangedCommand(BookReturnViewModel viewModel)
        {
            _viewModel = viewModel;
            _borrowingService = new BookBorrowingService(new BookBorrowingRepository());
        }

        public override void Execute(object? parameter)
        {
            _viewModel.Borrowings.Clear();
            foreach (var borrowing in _borrowingService.GetAllBorrowed(parameter.ToString()))
            {
                _viewModel.Borrowings.Add(borrowing);
            }

            _viewModel.HasSelectedBorrowing = false;
        }
    }
}
