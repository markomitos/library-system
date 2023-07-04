using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;

namespace LibrarySystem.Reservations
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;
        private TitleService _titleService = new TitleService(new TitleRepository());
        private CopiesService _copiesService = new CopiesService(new CopiesRepository());

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository=reservationRepository;
        }

        public void Add(Reservation reservation)
        {
            _reservationRepository.Add(reservation);
        }

        public Reservation? Get(int id)
        {
            return _reservationRepository.Get(id);
        }

        public void Save()
        {
            _reservationRepository.Save();
        }

        public ObservableCollection<Reservation> GetNotFinishedReservations(string loggedUser)
        {
            return _reservationRepository.GetNotFinishedReservations(loggedUser);
        }

        public void CancelExpiredReservations()
        {
            _reservationRepository.CancelExpiredReservations();
        }

        public void ApproveNextInQueueForBook(int reservationTitleUdk, int? reservationCopyId)
        {
            _reservationRepository.ApproveNextInQueueForBook(reservationTitleUdk, reservationCopyId);
        }

        public void Reserve(int titleUdk, string jmbg)
        {
            var copyId = _titleService.GetAvailableCopy(titleUdk);
            Reservation reservation = new(jmbg,titleUdk);
            if (copyId != -1)
            {
                reservation.AssignCopy(copyId);
                reservation.Approve();
                _copiesService.Reserve(copyId);
            }
            else
            {
                reservation.PutOnWaitList();
            }
            Add(reservation);
        }
    }
}
