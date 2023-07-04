using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using LibrarySystem.BookBorrowings.Commands;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.ViewModel
{
    public class BookBorrowingViewModel : ViewModelBase
    {
        private ObservableCollection<TitleViewModel> _titles;
        public ObservableCollection<TitleViewModel> Titles
        {
            get { return _titles; }
            set
            {
                _titles = value;
                OnPropertyChanged(nameof(Titles));
            }
        }

        private ObservableCollection<BookViewModel> _books;
        public ObservableCollection<BookViewModel> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private ObservableCollection<Copy> _copies;
        public ObservableCollection<Copy> Copies
        {
            get { return _copies; }
            set
            {
                _copies = value;
                OnPropertyChanged(nameof(Copies));
            }
        }

        private ObservableCollection<String> _members;
        public ObservableCollection<String> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        private TitleViewModel _selectedTitle;
        public TitleViewModel SelectedTitle
        {
            get { return _selectedTitle; }
            set
            {
                _selectedTitle = value;
                OnPropertyChanged(nameof(SelectedTitle));
            }
        }

        private BookViewModel _selectedBook;
        public BookViewModel SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private Copy _selectedCopy;
        public Copy SelectedCopy
        {
            get { return _selectedCopy; }
            set
            {
                _selectedCopy = value;
                OnPropertyChanged(nameof(SelectedCopy));
            }
        }

        private String _selectedMember;
        public String SelectedMember
        {
            get { return _selectedMember; }
            set
            {
                _selectedMember = value;
                OnPropertyChanged(nameof(SelectedMember));
            }
        }


        public ICommand LoadBooksCommand { get; set; }
        public ICommand LoadCopiesCommand { get; set; }
        public ICommand BorrowBookCommand { get; set; }

        public TitleService TitleService { get; set; }
        public MemberService MemberService { get; set; }
        public DateTime ReturnDate { get; set; }

        public BookBorrowingViewModel(BookBorrowingView bookBorrowingView)
        {
            LoadData();
            LoadBooksCommand = new LoadBooksCommand(this);
            LoadCopiesCommand = new LoadCopiesCommand(this);
            BorrowBookCommand = new BorrowBookCommand(this,bookBorrowingView);
        }

        public void LoadData()
        {
            TitleService = new TitleService(new TitleRepository());
            MemberService = new MemberService(new MemberRepository());
            //Titles = new ObservableCollection<Title>(TitleService.GetAll());
            Members = new ObservableCollection<string>(MemberService.GetAllMembersJmbg());
            ReturnDate = DateTime.Now;
            LoadTitles();
        }

        public void LoadTitles()
        {
            Titles = new ObservableCollection<TitleViewModel>();
            foreach (var title in TitleService.GetAll())
            {
                Titles.Add(new TitleViewModel(title.Name,title.Language,title.UDK,title.Genre,title.Authors));
            }
        }

        public void LoadBooks(List<Book> books)
        {
            Books = new ObservableCollection<BookViewModel>();

            foreach (var book in books)
            {
                Books.Add(new BookViewModel(book.ISBN,book.Published,book.Covering,book.Format,book.TitleUDK,book.PublisherName));
            }
        }
    }
}
