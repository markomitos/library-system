using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Utils;
using LibrarySystem.Users.Members;

namespace LibrarySystem.BookLoan
{
    public class BookLoanViewModel : ViewModelBase
    {
        private ObservableCollection<Title> _titles;
        public ObservableCollection<Title> Titles
        {
            get { return _titles; }
            set
            {
                _titles = value;
                OnPropertyChanged(nameof(Titles));
            }
        }

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
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

        private ObservableCollection<Member> _members;
        public ObservableCollection<Member> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        private Title _selectedTitle;
        public Title SelectedTitle
        {
            get { return _selectedTitle; }
            set
            {
                _selectedTitle = value;
                OnPropertyChanged(nameof(SelectedTitle));
            }
        }

        private Book _selectedBook;
        public Book SelectedBook
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



        public ICommand LoadBooksCommand { get; set; }
        public ICommand LoadCopiesCommand { get; set; }
        public ICommand LoanBookCommand { get; set; }

        public TitleService TitleService { get; set; }

        public BookLoanViewModel()
        {
            LoadData();
            LoadBooksCommand = new LoadBooksCommand(this);
        }

        public void LoadData()
        {
            TitleService = new TitleService(new TitleRepository());
            Titles = new ObservableCollection<Title>(TitleService.GetAllTitles());
        }
    }
}
