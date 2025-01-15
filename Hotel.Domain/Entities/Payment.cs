using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    internal class Payment
    {
        public int Id { get; set; }
        public int RezerwacjaId { get; set; }
        public decimal Kwota { get; set; }
        public DateTime DataPlatnosci { get; set; }
        public string MetodaPlatnosci { get; set; }
        public Reservation Reservation{ get; set; }
    }
}
