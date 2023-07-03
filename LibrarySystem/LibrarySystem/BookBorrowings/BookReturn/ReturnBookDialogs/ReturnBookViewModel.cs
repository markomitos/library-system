using System.Security.RightsManagement;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;
using System.Windows;
using System.Windows.Input;
using LibrarySystem.BookBorrowings.BookReturn.Commands;

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

        public ReturnBookDialog ReturnBookDialog;

        private string _fee;
        public string Fee
        {
            get
            {
                return _fee;
            }
            set
            {
                _fee = value;
                OnPropertyChanged(nameof(Fee));
            }
        }

        private bool _isFeePayed;

        public bool IsFeePayed
        {
            get{
                return _isFeePayed;
            }
            set
            {
                _isFeePayed = value;
                OnPropertyChanged(nameof(IsFeePayed));
            }
        }

        private bool _showFeeButton;
        public bool ShowFeeButton
        {
            get
            {
                return _showFeeButton;
            }
            set
            {
                _showFeeButton = value;
                OnPropertyChanged(nameof(ShowFeeButton));
            }
        }

        private ICommand _payFeeCommand;

        public ICommand PayFeeCommand
        {
            get
            {
                return _payFeeCommand ??= new PayFeeCommand(this);
            }
        }
        public ReturnBookViewModel(BookBorrowing borrowing, BookBorrowingService borrowingService, CopiesService copiesService, ReturnBookDialog returnBookDialog)
        {
            Borrowing = borrowing;
            _borrowingService = borrowingService;
            _copiesService = copiesService;
            ReturnBookDialog = returnBookDialog;
            CheckFee();
            LoadData();
        }

        private void CheckFee()
        {
            var fee = _borrowingService.CalculateFee(Borrowing);
            Fee = fee > 0 ? "Fee:  " + fee.ToString() : "";
            IsFeePayed = fee == 0;
            ShowFeeButton = fee > 0;
        }

        public void LoadData()
        {
            Copy = _copiesService.Get(Borrowing.CopyId);
            Title = _copiesService.GetTitleName(Copy.Id);
        }
    }
    
}
