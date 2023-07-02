using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BookBorrowing.Borrowing
{
    public class BookBorrowing
    {
        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsBookReturned { get; set; }
        public bool IsBookLost { get; set; }

        public int BookId { get; set; }

        public string Jmbg { get; set; }
        public BookBorrowing(int id, DateTime returnDate, DateTime borrowDate, bool isBookReturned, bool isBookLost, int bookId, string jmbg)
        {
            Id = id;
            ReturnDate = returnDate;
            BorrowDate = borrowDate;
            IsBookReturned = isBookReturned;
            IsBookLost = isBookLost;
            BookId = bookId;
            Jmbg = jmbg;
        }
    }
}
