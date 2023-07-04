using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Inventory.Books;
using LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging
{
    public class EditBookDialogViewModel : ViewModelBase
    {
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        private Book _selectedBook;
        public EditBookDialog EditBookDialog;
        public List<int> Copies;
        public int Isbn;
        public int TitleUdk;
        public EditBookDialogViewModel(EditBookDialog editBookDialog, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
            EditBookDialog = editBookDialog;
            _selectedBook = _specializedLibrarianViewModel.SelectedBook; 
            LoadData();
        }

        private void LoadData()
        {
            Isbn = _selectedBook.ISBN;
            PublisherName = _selectedBook.PublisherName;
            Covering = _selectedBook.Covering;
            SelectedDate = _selectedBook.Published;
            LoadFormats();
            SelectedFormat = _selectedBook.Format;
            Copies = _selectedBook.Copies;
            TitleUdk = _selectedBook.TitleUDK;
        }

        private void LoadFormats()
        {
            Formats = new ObservableCollection<Book.BookFormat>();
            Formats.Add(Book.BookFormat.Physical);
            Formats.Add(Book.BookFormat.Audio);
        }

        private string? _publisherName;
        private string? _covering;
        private Book.BookFormat _selectedFormat;
        private DateTime _selectedDate;
        private ObservableCollection<Book.BookFormat>? _formats;
        public ObservableCollection<Book.BookFormat>? Formats
        {
            get => _formats;
            set
            {
                _formats = value;
                OnPropertyChanged(nameof(Formats));
            }
        }

        public string? PublisherName
        {
            get => _publisherName;
            set
            {
                _publisherName = value;
                OnPropertyChanged(nameof(PublisherName));
            }
        }

        public string? Covering
        {
            get => _covering;
            set
            {
                _covering = value;
                OnPropertyChanged(nameof(Covering));
            }
        }

        public Book.BookFormat SelectedFormat
        {
            get => _selectedFormat;
            set
            {
                _selectedFormat = value;
                OnPropertyChanged(nameof(SelectedFormat));
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        private ICommand _editBookCommand;

        public ICommand EditBookCommand
        {
            get { return _editBookCommand ??= new EditBookCommand(this, _specializedLibrarianViewModel); }
        }
    }
}
