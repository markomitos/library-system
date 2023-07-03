using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Inventory.Titles
{
    public class TitleService
    {
        private readonly TitleRepository _titleRepository;

        public TitleService(TitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public void Add(Title title)
        {
            _titleRepository.Add(title);
        }

        public Title? Get(int udk)
        {
            return _titleRepository.Get(udk);
        }

        public List<Title> GetAll()
        {
            return _titleRepository.GetAll();
        }

        public bool AlreadyExists(int udk)
        {
            return _titleRepository.AlreadyExists(udk);
        }

        public void AddBook(int udk, int isbn)
        {
            _titleRepository.AddBook(udk, isbn);
        }

        public string GetTitleName(int isbn)
        {
            return _titleRepository.GetTitleName(isbn);
        }
    }
}
