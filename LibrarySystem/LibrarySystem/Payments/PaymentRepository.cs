﻿using LibrarySystem.BookBorrowings.Borrowing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Payments
{
    public class PaymentRepository
    {
        public const string PaymentsFilePath = "..\\..\\..\\Payments\\payments.json";
        public ObservableCollection<Payment> Payments = new();

        public PaymentRepository()
        {
            if (!File.Exists(PaymentsFilePath)) return;

            string json = File.ReadAllText(PaymentsFilePath);
            Payments = new(JsonConvert.DeserializeObject<List<Payment>>(json));
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Payments, Formatting.Indented);
            File.WriteAllText(PaymentsFilePath, json);
        }

        public void Add(Payment payment)
        {
            Payments.Add(payment);
            Save();
        }

        public ObservableCollection<Payment> Get(DateTime date)
        {
            return new (Payments.Where(payment => payment.Date.Date == date.Date));
        }

        public int GetTotalAmount(DateTime date)
        {
            return Get(date).Sum(payment => payment.Amount);
        }
    }
}
