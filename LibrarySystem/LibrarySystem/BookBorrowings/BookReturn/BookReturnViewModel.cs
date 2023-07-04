using System.Collections.ObjectModel;
using System.Windows.Input;
using LibrarySystem.BookBorrowings.BookReturn.Commands;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn
{
    public class BookReturnViewModel : ViewModelBase
    {
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

        private BookBorrowing _selectedBorrowing;
        public BookBorrowing SelectedBorrowing
        {
            get { return _selectedBorrowing; }
            set
            {
                _selectedBorrowing = value;
                OnPropertyChanged(nameof(SelectedBorrowing));
            }
        }

        private bool _hasSelectedBorrowing;

        public bool HasSelectedBorrowing
        {
            get { return _hasSelectedBorrowing;  }
            set
            {
                _hasSelectedBorrowing = value;
                OnPropertyChanged(nameof(HasSelectedBorrowing));
            }
        }

        private Member _selectedMember;

        public Member SelectedMember
        {
            get { return _selectedMember; }
            set
            {
                _selectedMember = value;
                OnPropertyChanged(nameof(SelectedMember));
            }
        }

        private ObservableCollection<BookBorrowing> _borrowings;

        public ObservableCollection<BookBorrowing> Borrowings
        {
            get { return _borrowings; }
            set
            {
                _borrowings = value;
                OnPropertyChanged(nameof(Borrowings));
            }
        }

        private MemberService _memberService { get; set; }
        private BookBorrowingService _borrowingService { get; set; }

        private ICommand _selectedMemberChangedCommand;
        public ICommand SelectedMemberChangedCommand
        {
            get
            {
                return _selectedMemberChangedCommand ??= new SelectedMemberChangedCommand(this);
            }
        }

        private ICommand _enableBookReturnButtonCommand { get; set; }

        public ICommand EnableBookReturnButtonCommand
        {
            get
            {
                return _enableBookReturnButtonCommand ??= new EnableReturnBookButtonCommand(this);
            }
        }

        private ICommand _showReturnBookDialogCommand { get; set; }

        public ICommand ShowReturnBookDialogCommand
        {
            get
            {
                return _showReturnBookDialogCommand ??= new ShowReturnBookDialogCommand(this);
            }
        }

        public BookReturnWindow BookReturnWindow;
        public BookReturnViewModel(MemberService memberService, BookBorrowingService borrowingService, BookReturnWindow bookReturnWindow)
        {
            _memberService = memberService;
            _borrowingService = borrowingService;
            BookReturnWindow = bookReturnWindow;
            LoadData();
        }



        public void LoadData()
        {
            _members = _memberService.GetAll();
            SelectedMember = Members[0];
            Borrowings = _borrowingService.GetAllBorrowed(SelectedMember.Jmbg);
        }
    }
}
