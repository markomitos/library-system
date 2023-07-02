using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Reservations
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public string UserJMBG { get; set; }
        public int? CopyId { get; set; }
        public int TitleUDK { get; set; }
    }
}
