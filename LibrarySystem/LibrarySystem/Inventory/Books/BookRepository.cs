using LibrarySystem.Inventory.Copies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Inventory.Books
{
    public class BookRepository
    {
        public const string BooksFilePath = "..\\..\\..\\Inventory\\Books\\books.json";
        public List<Book> Books = new();

        public BookRepository()
        {
            if (!File.Exists(BooksFilePath)) return;

            string json = File.ReadAllText(BooksFilePath);
            Books = JsonConvert.DeserializeObject<List<Book>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Books, Formatting.Indented);
            File.WriteAllText(BooksFilePath, json);
        }

        public void Add(Book book)
        {
            Books.Add(book);
            Save();
        }

        public Book? Get(int isbn)
        {
            return Books.FirstOrDefault(book => book.ISBN == isbn);
        }

        public List<Book> GetBooksByIsbn(List<int> isbns)
        {
            return (from isbn in isbns from book in Books where isbn == book.ISBN select book).ToList();
        }

        public List<Book> GetBooksByUDK(int udk)
        {
            List<Book> retBooks = new();
            foreach (Book book in Books)
            {
                if(book.TitleUDK == udk) retBooks.Add(book);
            }

            return retBooks;
        }

        public List<Book> GetAllBooks()
        {
            return Books;
        }

        public bool AlreadyExists(int isbn)
        {
            foreach (Book book in Books)
            {
                if (book.ISBN == isbn) return true;
            }

            return false;
        }

        public void AddCopy(int selectedBookIsbn, int copyId)
        {
            Get(selectedBookIsbn).Copies.Add(copyId);
            Save();
        }

        public int GetISBN(int copyId)
        {
            return Books.FirstOrDefault(book => book.Copies.Contains(copyId)).ISBN;
        }
    }
}
