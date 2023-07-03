using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Payments
{
    public class Payment
    {
        public int Price { get; set; }
        public DateTime Time { get; set; }

        public string Reason { get; set; }

        public Payment(int price, DateTime time, string reason)
        {
            Price = price;
            Time = time;
            Reason = reason;
        }
    }
}
