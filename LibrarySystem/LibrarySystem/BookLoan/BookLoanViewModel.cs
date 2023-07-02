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
        public ObservableCollection<Title> Titles { get; set; }

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



        public ICommand LoadBooksCommand { get; set; }
        public ICommand LoadCopiesCommand { get; set; }
        public ICommand LoanBookCommand { get; set; }

        public TitleService TitleService { get; set; }

        public BookLoanViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            TitleService = new TitleService(new TitleRepository());
            Titles = new ObservableCollection<Title>(TitleService.GetAllTitles());
        }
    }
}
