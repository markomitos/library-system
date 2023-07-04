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

        public List<int> Books { get; set; }


        public Title(string name, string language, int udk, string genre, List<string> authors, List<int> books)
        {
            if (name == "") throw new ArgumentNullException("name can't be empty");
            if (language == "") throw new ArgumentNullException("language can't be empty");
            if (genre == "") throw new ArgumentNullException("genre can't be empty");
            if (authors.Count == 0) throw new ArgumentException("A title must have at least one author!");
            Name = name;
            Language = language;
            UDK = udk;
            Genre = genre;
            Authors = authors;
            Books = books;
        }
    }
}
