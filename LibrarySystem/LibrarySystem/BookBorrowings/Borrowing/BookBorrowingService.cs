using System.Collections.ObjectModel;

namespace LibrarySystem.BookBorrowings.Borrowing
{
    public class BookBorrowingService
    {
        private readonly BookBorrowingRepository _bookBorrowingRepository;

        public BookBorrowingService(BookBorrowingRepository bookBorrowingRepository)
        {
            _bookBorrowingRepository = bookBorrowingRepository;
        }

        public void Add(BookBorrowing bookBorrowing)
        {
            _bookBorrowingRepository.Add(bookBorrowing);
        }

        public BookBorrowing? Get(int id)
        {
            return _bookBorrowingRepository.Get(id);
        }

        public ObservableCollection<BookBorrowing> GetAll(string jmbg)
        {
            return _bookBorrowingRepository.GetAll(jmbg);
        }
    }
}
