using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using Newtonsoft.Json;

namespace LibrarySystem.BookBorrowings.Borrowing
{
    public class BookBorrowingRepository
    {
        public const string BorrowingFilePath = "..\\..\\..\\BookBorrowings\\Borrowing\\borrowings.json";
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

        public void CreateBookBorrowing(DateTime returnDate, DateTime borrowDate, bool isBookReturned, bool isBookLost,
            int bookId, string jmbg)
        {
            Add(new BookBorrowing(GenerateBorrowingId(),returnDate,borrowDate,isBookReturned,isBookLost,bookId,jmbg));
        }


        public static int GenerateRandomId()
        {
            Random random = new Random();
            return random.Next(1, 1000);
        }

        public int GenerateBorrowingId()
        {
            while (true)
            {
                int id = GenerateRandomId();

                if (!(Get(id) == null))
                {
                    continue;
                }
                return id;
            }
        }


        public BookBorrowing? Get(int id)
        {
            return Borrowings.FirstOrDefault(borrowing => borrowing.Id == id);
        }

        public ObservableCollection<BookBorrowing> GetAll(string jmbg)
        {
            return new (Borrowings.Where(borrowing => borrowing.Jmbg == jmbg));
        }

        public ObservableCollection<BookBorrowing> GetAllBorrowed(string jmbg)
        {
            return new(GetAll(jmbg).Where(borrowing=>!borrowing.IsBookReturned));
        }

        public void Finish(BookBorrowing borrowing)
        {
            borrowing.Finish();
        }
    }
}
