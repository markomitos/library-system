using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Inventory.Copies
{
    public class Copy
    {
        public enum CopyStatus
        {
            Available,
            Rented,
            Lost,
            Reserved
        }

        public int Id { get; set; }
        public CopyStatus Status { get; set; }
        public int Price { get; set; }
        public bool IsDamaged { get; set; }
        public Copy(CopyStatus status, int price, bool isDamaged)
        {
            Status = status;
            Price = price;
            IsDamaged = isDamaged;
        }

        public void Borrow()
        {
            Status = CopyStatus.Rented;
        }
    }
}
