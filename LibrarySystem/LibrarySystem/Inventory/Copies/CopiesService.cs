using LibrarySystem.Inventory.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Titles;

namespace LibrarySystem.Inventory.Copies
{
    public class CopiesService
    {
        private readonly CopiesRepository _copiesRepository;
        private readonly BookService _bookService;

        public CopiesService(CopiesRepository copiesRepository)
        {
            _copiesRepository = copiesRepository;
            _bookService = new BookService(new BookRepository());
        }

        public CopiesService(CopiesRepository copiesRepository, BookService bookService)
        {
            _copiesRepository = copiesRepository;
            _bookService = bookService;
        }

        public void Add(Copy copy)
        {
            _copiesRepository.Add(copy);
        }

        public void BorrowCopy(int id)
        {
            _copiesRepository.BorrowCopy(id);
        }

        public Copy? Get(int id)
        {
            return _copiesRepository.Get(id);
        }

        public List<Copy> GetCopiesById(List<int> ids)
        {
            return _copiesRepository.GetCopiesById(ids);
        }

        public int GetISBN(int id)
        {
            return _bookService.GetISBN(id);
        }

        public string GetTitleName(int copyId)
        {
            return _bookService.GetTitleName(GetISBN(copyId));
        }
    }
}
