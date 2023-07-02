using LibrarySystem.Inventory.Titles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Publishing
{
    public class AuthorRepository
    {
        public const string TitlesFilePath = "..\\..\\..\\Publishing\\authors.json";
        public List<Author> Authors= new();

        public AuthorRepository()
        {
            if (!File.Exists(TitlesFilePath)) return;

            string json = File.ReadAllText(TitlesFilePath);
            Authors = JsonConvert.DeserializeObject<List<Author>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Authors, Formatting.Indented);
            File.WriteAllText(TitlesFilePath, json);
        }

        public void Add(Author author)
        {
            Authors.Add(author);
            Save();
        }

        public Author? Get(string id)
        {
            return Authors.FirstOrDefault(author => author.Id == id);
        }

        public List<Author> GetAll()
        {
            return Authors;
        }

        public List<string> GetAllToString()
        {
            List<string> readableAuthors = new List<string>();
            foreach (Author author in Authors)
            {
                readableAuthors.Add(author.Id + "|" + author.FirstName + "|" + author.LastName + "|" + author.BirthDate + "|" + author.Biography);
            }
            return readableAuthors;
        }
    }
}
