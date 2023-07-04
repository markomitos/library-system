using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands
{
    class EditBookCommand : CommandBase
    {
        EditBookDialogViewModel _viewModel;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        BookService _bookService = new BookService(new BookRepository());
        public EditBookCommand(EditBookDialogViewModel editBookDialogViewModel, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _viewModel = editBookDialogViewModel;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
        }

        public override void Execute(object? Parameter)
        {
            try
            {
                string publisherName = _viewModel.PublisherName;
                string covering = _viewModel.Covering;
                DateTime date = _viewModel.SelectedDate;
                Book.BookFormat format = _viewModel.SelectedFormat;
                List<int> copies = _viewModel.Copies;
                int isbn = _viewModel.Isbn;
                int titleUDK = _viewModel.TitleUdk;

                _bookService.Edit(new Book(isbn, date, covering, format, titleUDK, publisherName, copies));

                _specializedLibrarianViewModel._SpecializedLibrarianWindow.Close();
                SpecializedLibrarianWindow window = new();
                window.Show();
                _viewModel.EditBookDialog.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }

        }
    }
}
