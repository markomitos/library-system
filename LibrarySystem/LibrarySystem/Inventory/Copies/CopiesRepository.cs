﻿using LibrarySystem.Inventory.Titles;
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
            AssignId(copy);
            Copies.Add(copy);
            Save();
        }

        public void BorrowCopy(int id)
        {
            foreach (var copy in Copies.Where(copy => copy.Id == id))
            {
                copy.Borrow();
                break;
            }

            Save();
        }

        public Copy? Get(int id)
        {
            return Copies.FirstOrDefault(x => x.Id == id);
        }

        public List<Copy> GetCopiesById(List<int> ids)
        {
            return (from id in ids from copy in Copies where copy.Id == id select copy).ToList();
        }

        public void ReturnCopy(int id)
        {
            Get(id).Return();
            Save();
        }

        private int GenerateId()
        {
            Random rnd = new Random();
            return rnd.Next(1, 99999);
        }

        private bool ContainsId(int id)
        {
            foreach (var copy in Copies)
            {
                if (copy.Id == id) return true;
            }

            return false;
        }

        private void AssignId(Copy copy)
        {
            do
            {
                copy.Id = GenerateId();
            } while (ContainsId(copy.Id));
        }
    }
}
