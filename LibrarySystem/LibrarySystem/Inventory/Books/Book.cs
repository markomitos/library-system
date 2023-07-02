using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Publishing;

namespace LibrarySystem.Inventory.Books
{
    public class Book
    {
        public enum BookFormat
        {
            Audio,
            Physical
        }

        public int ISBN { get; set; }
        public DateTime Published { get; set; }
        public int Price { get; set; }
        public string Covering { get; set; }
        public BookFormat Format { get; set; }
        public int TitleUDK { get; set; }
        public string PublisherName { get; set; }
        public List<int> Copies { get; set; }

        public Book(int isbn, DateTime published, int price, string covering, BookFormat format, int titleUDK,
            string publisherName, List<int> copies)
        {
            if (covering == "") throw new ArgumentNullException("covering cant be empty!");
            if (publisherName == "") throw new ArgumentNullException("publisher name cant be empty!");
            ISBN = isbn;
            Published = published;
            Price = price;
            Covering = covering;
            Format = format;
            TitleUDK = titleUDK;
            PublisherName = publisherName;
            Copies = copies;
        }

    }
}
