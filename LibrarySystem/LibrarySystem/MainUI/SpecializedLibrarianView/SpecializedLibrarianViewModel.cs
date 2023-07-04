using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using LibrarySystem.BookBorrowings.ViewModel;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands;
using LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands;
using LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView
{
    public class SpecializedLibrarianViewModel : ViewModelBase
    {
        private readonly TitleService _titleService = new(new TitleRepository());
        public BookService _bookService = new(new BookRepository());
        public CopiesService _copyService = new(new CopiesRepository());

        public SpecializedLibrarianWindow _SpecializedLibrarianWindow;

        public ObservableCollection<TitleViewModel> Titles { get; set; }

        private ObservableCollection<Copy>? _copies;

        public ObservableCollection<Copy>? Copies
        {
            get => _copies;
            set
            {
                _copies = value;
                OnPropertyChanged(nameof(Copies));
            }
        }

        private ObservableCollection<Book>? _books;
        public ObservableCollection<Book>? Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private TitleViewModel? _selectedTitle;

        public TitleViewModel? SelectedTitle
        {
            get => _selectedTitle;
            set
            {
                _selectedTitle = value;
                OnPropertyChanged(nameof(SelectedTitle));
            }
        }

        private Book? _selectedBook;

        public Book? SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private Copy? _selectedCopy;

        public Copy? SelectedCopy
        {
            get => _selectedCopy;
            set
            {
                _selectedCopy = value;
                OnPropertyChanged(nameof(SelectedCopy));
            }
        }

        private ICommand _showAddTitleDialogCommand;

        public ICommand ShowAddTitleDialogCommand
        {
            get { return _showAddTitleDialogCommand ??= new ShowAddTitleDialogCommand(this); }
        }

        private ICommand _showAddBookDialogCommand;

        public ICommand ShowAddBookDialogCommand
        {
            get { return _showAddBookDialogCommand ??= new ShowAddBookDialogCommand(this); }
        }

        private ICommand _showAddCopyDialogCommand;

        public ICommand ShowAddCopyDialogCommand
        {
            get { return _showAddCopyDialogCommand ??= new ShowAddCopyDialogCommand(this); }
        }

        private ICommand _updateBookDataGridCommand;

        public ICommand UpdateBookDataGridCommand
        {
            get { return _updateBookDataGridCommand ??= new UpdateBookDataGridCommand(this); }
        }

        private ICommand _updateCopyDataGridCommand;

        public ICommand UpdateCopyDataGridCommand
        {
            get { return _updateCopyDataGridCommand ??= new UpdateCopyDataGridCommand(this); }
        }

        private ICommand _logoutCommand;

        public ICommand LogoutCommand
        {
            get { return _logoutCommand ??= new LogoutCommand(_SpecializedLibrarianWindow); }
        }

        private ICommand _removeTitleCommand;

        public ICommand RemoveTitleCommand
        {
            get { return _removeTitleCommand ??= new RemoveTitleCommand(this); }
        }

        private ICommand _removeBookCommand;

        public ICommand RemoveBookCommand
        {
            get { return _removeBookCommand ??= new RemoveBookCommand(this); }
        }

        private ICommand _removeCopyCommand;

        public ICommand RemoveCopyCommand
        {
            get { return _removeCopyCommand ??= new RemoveCopyCommand(this); }
        }

        private ICommand _showEditTitleDialogCommand;

        public ICommand ShowEditTitleDialogCommand
        {
            get { return _showEditTitleDialogCommand ??= new ShowEditTitleDialogCommand(this); }
        }

        private ICommand _showEditBookDialogCommand;

        public ICommand ShowEditBookDialogCommand
        {
            get { return _showEditBookDialogCommand ??= new ShowEditBookDialogCommand(this); }
        }

        private ICommand _showEditCopyDialogCommand;

        public ICommand ShowEditCopyDialogCommand
        {
            get { return _showEditCopyDialogCommand ??= new ShowEditCopyDialogCommand(this); }
        }


        public SpecializedLibrarianViewModel(SpecializedLibrarianWindow specializedLibrarianWindow)
        {
            LoadTitles();
            _SpecializedLibrarianWindow = specializedLibrarianWindow;

        }

        private void LoadTitles()
        {
            List<TitleViewModel> titleViewModels = new();
            foreach (Title title in _titleService.GetAll())
            {
                titleViewModels.Add(new TitleViewModel(title.Name, title.Language, title.UDK, title.Genre, title.Authors));
            }
            Titles = new ObservableCollection<TitleViewModel>(titleViewModels);
        }
    }
}
