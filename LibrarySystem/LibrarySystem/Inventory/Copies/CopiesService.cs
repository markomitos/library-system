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
        public CopiesService(CopiesRepository copiesRepository)
        {
            _copiesRepository = copiesRepository;
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
            return IsCopyDamaged(copyId) ? GetCopyPrice(copyId) : 0;
        }
      
        public void Remove(int copyId)
        {
            _copiesRepository.Remove(copyId);
        }

        public void Edit(int id, Copy copy)
        {
            _copiesRepository.Edit(id, copy);
        }
    }
}
