using LibrarySystem.Inventory.Books;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BookBorrowing.Borrowing
{
    public class BookBorrowingRepository
    {
        public const string BorrowingFilePath = "..\\..\\..\\BookBorrowing\\Borrowing\\borrowings.json";
        public ObservableCollection<BookBorrowing> Borrowings = new();

        public BookBorrowingRepository()
        {
            if (!File.Exists(BorrowingFilePath)) return;

            string json = File.ReadAllText(BorrowingFilePath);
            Borrowings = new(JsonConvert.DeserializeObject<List<BookBorrowing>>(json));
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Borrowings, Formatting.Indented);
            File.WriteAllText(BorrowingFilePath, json);
        }

        public void Add(BookBorrowing borrowing)
        {
            Borrowings.Add(borrowing);
            Save();
        }

        public BookBorrowing Get(int id)
        {
            return Borrowings.FirstOrDefault(borrowing => borrowing.Id == id);
        }

        public ObservableCollection<BookBorrowing> GetAll(string jmbg)
        {
            return new (Borrowings.Where(borrowing => borrowing.Jmbg == jmbg));
        }
    }
}
