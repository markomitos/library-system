using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;

namespace LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs
{
    public class ReturnBookViewModel:ViewModelBase
    {
        
        private MemberService _memberService { get; set; }
        private BookBorrowingService _borrowingService { get; set; }

        private CopiesService _copiesService { get; set; }

        public Copy Copy { get; set; }

        public BookBorrowing Borrowing { get; set; }

        public string Title { get; set; }
        public ReturnBookViewModel(BookBorrowing borrowing, BookBorrowingService borrowingService, CopiesService copiesService)
        {
            Borrowing = borrowing;
            _borrowingService = borrowingService;
            _copiesService = copiesService;
            LoadData();
        }

        public void LoadData()
        {
            Copy = _copiesService.Get(Borrowing.CopyId);
            Title = _copiesService.GetTitleName(Copy.Id);
        }
    }
    
}
