using System;
using System.Collections.Generic;
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
    }
}
