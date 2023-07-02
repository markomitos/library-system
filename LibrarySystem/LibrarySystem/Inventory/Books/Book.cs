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

        public int Isbn { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public string Covering { get; set; }
        public BookFormat Format { get; set; }
        public Title Title { get; set; }
        public Publisher Publisher { get; set; }
        public List<Copy> Copies { get; set; }



    }
}
