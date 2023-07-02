using LibrarySystem.Inventory.Titles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Reservations
{
    public class ReservationRepository
    {
        public const string ReservationFilePath = "..\\..\\..\\Reservations\\reservations.json";
        public List<Reservation> Reservations = new();

        public ReservationRepository()
        {
            if (!File.Exists(ReservationFilePath)) return;

            string json = File.ReadAllText(ReservationFilePath);
            Reservations = JsonConvert.DeserializeObject<List<Reservation>>(json);
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Reservations, Formatting.Indented);
            File.WriteAllText(ReservationFilePath, json);
        }

        public void Add(Reservation reservation)
        {
            Reservations.Add(reservation);
            Save();
        }

        public Reservation? Get(int id)
        {
            return Reservations.FirstOrDefault(reservation => reservation.Id == id);
        }
    }
}
