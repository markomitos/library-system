﻿using LibrarySystem.Inventory.Titles;
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
        private readonly TitleService _titleService;
        private readonly CopiesService _copiesService = new(new CopiesRepository());

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _titleService = new TitleService(new TitleRepository());
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

        public string GetTitleName(int isbn)
        {
            return _titleService.GetTitleName(isbn);
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
    }
}
