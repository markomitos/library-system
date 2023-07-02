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
    }
}
