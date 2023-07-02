using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Publishing;

namespace LibrarySystem.Inventory.Titles
{
    public class Title
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public int UDK { get; set; }
        public string Genre { get; set; }
        public List<string> Authors { get; set; }

        public List<string> Books { get; set; }


        public Title(string name, string language, int udk, string genre, List<string> authors, List<string> books)
        {
            Name = name;
            Language = language;
            UDK = udk;
            Genre = genre;
            Authors = authors;
            Books = books;
        }
    }
}
