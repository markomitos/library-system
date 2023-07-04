using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn.Commands
{
    public class EnableReturnBookButtonCommand : CommandBase
    {
        private BookReturnViewModel _viewModel;

        public EnableReturnBookButtonCommand(BookReturnViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.HasSelectedBorrowing = true;
        }
    }
}
