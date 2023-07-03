using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Reservations
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;

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
    }
}
