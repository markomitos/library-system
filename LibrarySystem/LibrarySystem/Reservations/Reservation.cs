using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Reservations
{
    public class Reservation
    {
        public enum ReservationState
        {
            Created,
            Canceled,
            Waiting,
            Approved,
            Ended
        }
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public ReservationState State { get; set; }
        public string UserJMBG { get; set; }
        public int? CopyId { get; set; }
        public int TitleUDK { get; set; }

        public void Approve()
        {
            State = ReservationState.Approved;
            ApprovalDate = DateTime.Now;
        }

        public Reservation(int id, DateTime reservationDate, DateTime? approvalDate, ReservationState state, string userJmbg, int? copyId, int titleUdk)
        {
            Id = id;
            ReservationDate = reservationDate;
            ApprovalDate = approvalDate;
            State = state;
            UserJMBG = userJmbg;
            CopyId = copyId;
            TitleUDK = titleUdk;
        }

        public Reservation(string userJmbg, int titleUdk)
        {
            ReservationDate = DateTime.Now;
            State = ReservationState.Created;
            UserJMBG = userJmbg;
            TitleUDK = titleUdk;
        }

        public Reservation()
        {
            
        }

        public void AssignCopy(int copyId)
        {
            CopyId = copyId;
        }

        public void PutOnWaitList()
        {
            State = ReservationState.Waiting;
        }
    }
}
