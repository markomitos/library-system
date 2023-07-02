using LibrarySystem.Inventory.Titles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Inventory.Copies
{
    public class CopiesRepository
    {
        public const string CopiesFilePath = "..\\..\\..\\Inventory\\Copies\\copies.json";
        public List<Copy> Copies = new();

        public CopiesRepository()
        {
            if (!File.Exists(CopiesFilePath)) return;

            string json = File.ReadAllText(CopiesFilePath);
            Copies = JsonConvert.DeserializeObject<List<Copy>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Copies, Formatting.Indented);
            File.WriteAllText(CopiesFilePath, json);
        }

        public void Add(Copy copy)
        {
            Copies.Add(copy);
            Save();
        }

        public Copy? Get(int id)
        {
            return Copies.FirstOrDefault(x => x.Id == id);
        }
    }
}
