using System.Security.RightsManagement;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Users.Members;
using LibrarySystem.Utils;
using System.Windows;
using System.Windows.Input;
using LibrarySystem.BookBorrowings.BookReturn.Commands;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Titles;

namespace LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs
{
    public class ReturnBookViewModel:ViewModelBase
    {
        
        private BookBorrowingService _borrowingService { get; set; }

        private CopiesService _copiesService { get; set; }

        private BookService _bookService = new BookService(new BookRepository());

        private TitleService _titleService = new TitleService(new TitleRepository());

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

        public int FeeAmount;

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

        private ICommand _returnBookCommand;

        public ICommand ReturnBookCommand
        {
            get
            {
                return _returnBookCommand ??= new ReturnBookCommand(this,_borrowingService);
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
            FeeAmount = _borrowingService.CalculateFee(Borrowing);
            Fee = FeeAmount > 0 ? "Fee:  " + FeeAmount.ToString() : "";
            IsFeePayed = FeeAmount == 0;
            ShowFeeButton = FeeAmount > 0;
        }

        public void LoadData()
        {
            Copy = _copiesService.Get(Borrowing.CopyId);
            Title = _titleService.GetTitleName(_bookService.GetISBN(Borrowing.CopyId));
        }

        public void RefreshData()
        {
            ReturnBookDialog.BookReturnWindow.Close();
            BookReturnWindow newBookReturnWindow = new BookReturnWindow();
            newBookReturnWindow.Show();
            ReturnBookDialog.Close();
        }
    }
    
}
