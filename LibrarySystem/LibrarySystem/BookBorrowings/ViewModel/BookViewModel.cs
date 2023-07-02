using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibrarySystem.Inventory.Books.Book;

namespace LibrarySystem.BookBorrowings.ViewModel
{
    public class BookViewModel
    {
        public int ISBN { get; set; }
        public DateTime Published { get; set; }
        public int Price { get; set; }
        public string Covering { get; set; }
        public BookFormat Format { get; set; }
        public int TitleUDK { get; set; }
        public string Publisher { get; set; }

        public BookViewModel(int isbn, DateTime published, int price, string covering, BookFormat format, int titleUdk, string publisherName)
        {
            ISBN = isbn;
            Published = published;
            Price = price;
            Covering = covering;
            Format = format;
            TitleUDK = titleUdk;
            Publisher = publisherName;
        }
    }
}
