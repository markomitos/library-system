﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;

namespace LibrarySystem.Inventory.Titles
{
    public class TitleService
    {
        private readonly TitleRepository _titleRepository;
        private readonly BookService _bookService = new(new BookRepository());

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
      
        public void Remove(int titleUdk)
        {
            Title title = Get(titleUdk);
            _titleRepository.Remove(titleUdk);
            for (int i = 0; i < title.Books.Count; i++)
            {
                _bookService.Remove(title.Books[i]);
            }
        }

        public void RemoveBook(int titleUdk, int isbn)
        {
            _titleRepository.RemoveBook(titleUdk, isbn);
            _bookService.Remove(isbn);
        }

        public void Edit(Title title)
        {
            _titleRepository.Edit(title);
        }
        public int GetAvailableCopy(int titleUdk)
        {
            var copyId = -1;
            Title title = Get(titleUdk);
            for (int i = 0; i < title.Books.Count; i++)
            { 
                copyId = _bookService.GetAvailableCopy(title.Books[i]);
                if (copyId != -1)
                {
                    break;
                }
            }
            return copyId;
        }
    }
}
