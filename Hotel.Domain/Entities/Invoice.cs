using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime DataWystawienia { get; set; }
        public decimal Kwota { get; set; }
        public string MetodaPlatnosci { get; set; }
        public int RezerwacjaId { get; set; }
        public Reservation Reservation{ get; set; }
    }
}
