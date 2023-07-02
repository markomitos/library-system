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
            return isbns.Select(isbn => Get(isbn)).ToList();
        }
    }
}
