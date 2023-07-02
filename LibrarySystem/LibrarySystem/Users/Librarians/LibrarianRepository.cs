using LibrarySystem.Users.Accounts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Users.Librarians
{
    public class LibrarianRepository
    {
        public const string LibrariansFilePath = "..\\..\\..\\Users\\Librarians\\librarians.json";
        public List<Librarian> Librarians = new();

        public LibrarianRepository()
        {
            if (!File.Exists(LibrariansFilePath)) return;

            string json = File.ReadAllText(LibrariansFilePath);
            Librarians = JsonConvert.DeserializeObject<List<Librarian>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Librarians, Formatting.Indented);
            File.WriteAllText(LibrariansFilePath, json);
        }

        public void Add(Librarian librarian)
        {
            Librarians.Add(librarian);
            Save();
        }

        public Librarian? Get(string jmbg)
        {
            return Librarians.FirstOrDefault(librarian => librarian.Jmbg == jmbg);
        }

        public bool Contains(string jmbg)
        {
            return Librarians.Any(librarian => librarian.Jmbg == jmbg);
        }
    }
}
