using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Publishing
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void Add(Author author)
        {
            _authorRepository.Add(author);
        }

        public Author? Get(string id)
        {
            return _authorRepository.Get(id);
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public List<string> GetAllToString()
        {
            return _authorRepository.GetAllToString();
        }
    }
}
