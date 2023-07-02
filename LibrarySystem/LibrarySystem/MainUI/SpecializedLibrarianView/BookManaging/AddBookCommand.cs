using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging
{
    class AddBookCommand : CommandBase
    {
        AddBookViewModel _viewModel;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        private BookService _bookService = new(new BookRepository());
        private TitleService _titleService = new(new TitleRepository());
        public AddBookCommand(AddBookViewModel viewModel, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _viewModel = viewModel;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
        }

        public override void Execute(object? Parameter)
        {
            try
            {
                int isbn = int.Parse(_viewModel._addBookdialog.ISBNTextBox.Text);
                int price = int.Parse(_viewModel._addBookdialog.PriceTextBox.Text);
                string covering = _viewModel._addBookdialog.CoveringTextBox.Text;
                string publisherName = _viewModel._addBookdialog.PublisherNameTextBox.Text;
                DateTime publishingDate = _viewModel._addBookdialog.PublishedDatePicker.SelectedDate.Value;
                Book.BookFormat format = (Book.BookFormat)Enum.Parse(typeof(Book.BookFormat), _viewModel._addBookdialog.FormatComboBox.Text);
                int udk = _specializedLibrarianViewModel.SelectedTitle.UDK;

                if (_bookService.AlreadyExists(isbn))
                {
                    throw new Exception("Book with this ISBN already exists!");
                }

                _bookService.Add(new Book(isbn, publishingDate, price, covering, format, udk, publisherName, new List<int>()));
                _titleService.AddBook(udk, isbn);

                Notification.ShowSuccessDialog("Successfully added a book!");
                _viewModel._addBookdialog.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }
        }
    }
}
