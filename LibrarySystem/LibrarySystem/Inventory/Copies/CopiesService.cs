using LibrarySystem.Inventory.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
