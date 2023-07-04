using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Payments
{
    public class Payment
    {
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public string Reason { get; set; }

        public Payment(int amount, DateTime date, string reason)
        {
            Amount = amount;
            Date = date;
            Reason = reason;
        }
    }
}
