using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.Librarians
{
    public class LibraryService
    {
        private readonly LibrarianRepository _librarianRepository;

        public LibraryService(LibrarianRepository librarianRepository)
        {
            _librarianRepository = librarianRepository;
        }

        public void Add(Librarian librarian)
        {
            _librarianRepository.Add(librarian);
        }

        public Librarian? Get(string jmbg)
        {
            return _librarianRepository.Get(jmbg);
        }
    }
}
