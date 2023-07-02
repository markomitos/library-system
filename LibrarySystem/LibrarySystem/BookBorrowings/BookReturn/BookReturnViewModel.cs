using System.Collections.ObjectModel;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn
{
    public class BookReturnViewModel : ViewModelBase
    {


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

        public BookReturnViewModel(MemberService memberService)
        {
            _memberService = memberService;
            LoadData();
        }

        public void LoadData()
        {
            _members = _memberService.GetAll();
        }
    }
}
