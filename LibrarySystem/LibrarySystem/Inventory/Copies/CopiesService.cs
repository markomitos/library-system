using LibrarySystem.Inventory.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs;
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

        public void ReturnCopy(int id)
        {
            _copiesRepository.ReturnCopy(id);
        }

        public bool IsCopyDamaged(int id)
        {
            return _copiesRepository.IsCopyDamaged(id);
        }

        public int GetCopyPrice(int id)
        {
            return _copiesRepository.GetCopyPrice(id);
        }

        public int CalculateDamagedFee(int copyId)
        {
            return IsCopyDamaged(copyId) ? 0 : GetCopyPrice(copyId);
        }
    }
}
