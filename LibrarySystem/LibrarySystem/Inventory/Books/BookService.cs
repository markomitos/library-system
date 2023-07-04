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
        private readonly CopiesService _copiesService = new(new CopiesRepository());

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;        }

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

        public List<Book> GetBooksByUDK(int udk)
        {
            return _bookRepository.GetBooksByUDK(udk);
        }

        public bool AlreadyExists(int isbn)
        {
            return _bookRepository.AlreadyExists(isbn);
        }

        public void AddCopy(int selectedBookIsbn, int copyId)
        {
            _bookRepository.AddCopy(selectedBookIsbn, copyId);
        }

        public int GetISBN(int copyId)
        {
            return _bookRepository.GetISBN(copyId);
        }

        public void Remove(int isbn)
        {
            Book book = Get(isbn);
            _bookRepository.Remove(isbn);
            for (int i = 0; i < book.Copies.Count; i++)
            {
                _copiesService.Remove(book.Copies[i]);
            }
        }

        public void Edit(Book book)
        {
            _bookRepository.Edit(book);
        }
        public int GetAvailableCopy(int isbn)
        {
            int availableCopyId = -1;
            Book book = Get(isbn);
            foreach(var copyId in book.Copies)
            {
                var copy = _copiesService.Get(copyId);
                if (copy.IsAvailable())
                {
                    availableCopyId = copyId;
                    break;
                }
            }
            return availableCopyId;
        }
    }
}
