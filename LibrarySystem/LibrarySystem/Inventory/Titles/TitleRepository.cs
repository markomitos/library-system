using LibrarySystem.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public string GetTitleName(int isbn)
        {
            return Titles.FirstOrDefault(title => title.Books.Contains(isbn)).Name;
        }
      
        public void Remove(int titleUdk)
        {
            Titles.Remove(Get(titleUdk));
            Save();
        }

        public void Edit(Title newTitle)
        {
            foreach (Title title in Titles)
            {
                if (title.UDK == newTitle.UDK)
                {
                    title.Name = newTitle.Name;
                    title.Language = newTitle.Language;
                    title.Genre = newTitle.Genre;
                    title.Authors = newTitle.Authors;
                    title.Books = newTitle.Books;
                    
                    Save();
                    return;
                }
            }
        }
    }
}