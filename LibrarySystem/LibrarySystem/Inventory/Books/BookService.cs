using LibrarySystem.Inventory.Titles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;

namespace LibrarySystem.Inventory.Copies
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public Book? Get(int isbn)
        {
            return _bookRepository.Get(isbn);
        }

        public List<Book> GetBooksByIsbn(List<int> isbns)
        {
            return _bookRepository.GetBooksByIsbn(isbns);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

    }
}
