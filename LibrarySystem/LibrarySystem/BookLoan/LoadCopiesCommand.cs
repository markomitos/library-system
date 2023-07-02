using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.MainUI.NotificationDialogs;

namespace LibrarySystem.BookLoan
{
    internal class LoadCopiesCommand : CommandBase
    {
        private BookBorrowingViewModel _viewModel;
        private CopiesService _copiesService;

        public LoadCopiesCommand(BookBorrowingViewModel viewModel)
        {
            _viewModel = viewModel;
            _copiesService = new CopiesService(new CopiesRepository());
        }

        public override void Execute(object? parameter)
        {
            try
            {
                List<Copy> copies = _copiesService.GetCopiesById(_viewModel.SelectedBook.Copies);

                if (copies.Count == 0) throw new Exception("There are no copies for chosen book! ");
                _viewModel.Copies = new ObservableCollection<Copy>(copies);
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
                _viewModel.Copies = new ObservableCollection<Copy>(new List<Copy>());
            }

        }

    }
}
