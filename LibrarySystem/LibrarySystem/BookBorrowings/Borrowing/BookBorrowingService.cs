using System;
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

        public void CreateBookBorrowing(DateTime returnDate, DateTime borrowDate, bool isBookReturned, bool isBookLost,
            int bookId, string jmbg)
        {
            _bookBorrowingRepository.CreateBookBorrowing(returnDate,borrowDate,isBookReturned,isBookLost,bookId,jmbg);
        }

        public BookBorrowing? Get(int id)
        {
            return _bookBorrowingRepository.Get(id);
        }

        public ObservableCollection<BookBorrowing> GetAll(string jmbg)
        {
            return _bookBorrowingRepository.GetAll(jmbg);
        }

        public ObservableCollection<BookBorrowing> GetAllBorrowed(string jmbg)
        {
            return _bookBorrowingRepository.GetAllBorrowed(jmbg);
        }
    }
}
