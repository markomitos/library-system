using LibrarySystem.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
