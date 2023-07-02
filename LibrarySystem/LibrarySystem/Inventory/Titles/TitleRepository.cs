using LibrarySystem.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Books;

namespace LibrarySystem.Inventory.Titles
{
    public class TitleRepository
    {
        public const string TitlesFilePath = "..\\..\\..\\Inventory\\Titles\\titles.json";
        public List<Title> Titles = new();

        public TitleRepository()
        {
            if (!File.Exists(TitlesFilePath)) return;

            string json = File.ReadAllText(TitlesFilePath);
            Titles = JsonConvert.DeserializeObject<List<Title>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Titles, Formatting.Indented);
            File.WriteAllText(TitlesFilePath, json);
        }

        public void Add(Title title)
        {
            Titles.Add(title);
            Save();
        }

        public Title? Get(int udk)
        {
            return Titles.FirstOrDefault(title => title.UDK == udk);
        }

        public List<Title> GetAll()
        {
            return Titles;
        }

        public bool AlreadyExists(int udk)
        {
            foreach (var title in Titles)
            {
                if (title.UDK == udk) return true;
            }
            return false;
        }

        public void AddBook(int udk, int isbn)
        {
            Get(udk).Books.Add(isbn);
            Save();
        }
    }
}
