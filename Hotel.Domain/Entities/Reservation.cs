using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Reservation
    {
        public Reservation()
        {
            //Person = new UserUnregistered();
            Status = "Oczekująca";
        }

        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfGuests { get; set; }
        public bool CheckedIn { get; set; } = false;
        public bool CheckedOut { get; set; } = false;

        public int PriceTotal { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public string Status { get; set; }//Oczekująca/W trakcie/Zakończona/Anulowana
    }
}