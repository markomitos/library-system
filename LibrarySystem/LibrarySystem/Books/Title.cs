using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Books
{
    public class Title
    {
        public string Name {get; set; }
        public string Language { get; set; }
        public int Udk { get; set; }
        public string Genre { get; set; }
        public List<Author> Authors { get; set; }


        public Title(string name, string language, int udk, string genre)
        {
            Name = name;
            Language = language;
            Udk = udk;
            Genre = genre;
        }
    }
}
