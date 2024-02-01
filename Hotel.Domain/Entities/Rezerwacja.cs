using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Rezerwacja
    {
        public Rezerwacja()
        {
            Osoba = new UzytkownikNiezarejestrowany();
            Status = "Oczekująca";
        }

        public int Id { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int IloscOsob { get; set; }
        public bool CzyZameldowano { get; set; } = false;
        public bool CzyWymeldowano { get; set; } = false;

        public int CenaCalkowita { get; set; }

        public int PokojId { get; set; }
        public Room? Pokoj { get; set; }

        public Osoba? Osoba { get; set; }

        public string Status { get; set; }//Oczekująca/W trakcie/Zakończona/Anulowana
    }
}