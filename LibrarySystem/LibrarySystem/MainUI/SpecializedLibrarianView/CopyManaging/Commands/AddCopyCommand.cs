using System;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands
{
    class AddCopyCommand : CommandBase
    {
        AddCopyViewModel _viewModel;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        private CopiesService _copiesService = new(new CopiesRepository());
        private BookService _bookService = new(new BookRepository());
        public AddCopyCommand(AddCopyViewModel viewModel, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _viewModel = viewModel;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
        }

        public override void Execute(object? Parameter)
        {
            try
            {
                int price = int.Parse(_viewModel._addCopyDialog.priceTextBox.Text);
                int numberOfCopies = int.Parse(_viewModel._addCopyDialog.numberOfCopiesTextBox.Text);
                int isbn = _specializedLibrarianViewModel.SelectedBook.ISBN;

                if (price <= 0 || numberOfCopies <= 0)
                {
                    throw new Exception("Price and number of copies must be greater than 0!");
                }

                for (int i = 0; i < numberOfCopies; i++)
                {
                    Copy copy = new Copy(Copy.CopyStatus.Available, price, false);
                 _copiesService.Add(copy);
                 _bookService.AddCopy(isbn, copy.Id);
                }

                Notification.ShowSuccessDialog("Successfully added " + numberOfCopies + "copies!");
                _viewModel._specializedLibrarianViewModel._SpecializedLibrarianWindow.Close();
                SpecializedLibrarianWindow window = new();
                window.Show();
                _viewModel._addCopyDialog.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }
        }
    }
}
