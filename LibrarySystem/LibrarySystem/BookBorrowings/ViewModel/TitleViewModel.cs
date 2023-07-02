using System.Collections.Generic;
using LibrarySystem.Publishing;

namespace LibrarySystem.BookBorrowings.ViewModel
{
    public class TitleViewModel
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public int UDK { get; set; }
        public string Genre { get; set; }
        public string Authors { get; set; }
        public AuthorService AuthorService;

        public TitleViewModel(string name, string language, int udk, string genre, List<string> authors)
        {
            AuthorService = new AuthorService(new AuthorRepository());
            Name = name;
            Language = language;
            UDK = udk;
            Genre = genre;

            foreach (var author in authors)
            {
                Author authorName = AuthorService.Get(author);
                Authors += $"{authorName.FirstName} {authorName.LastName},";
            }
        }
    }
}
