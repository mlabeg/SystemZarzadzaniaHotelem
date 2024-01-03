using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Rezerwacja
    {
        private Rezerwacja()
        {
        }

        public Rezerwacja(int id, DateTime dataOd, DateTime dataDo, int iloscOsob, bool czyZameldowano, bool czyWymeldowano, Pokoj pokoj, Osoba osoba)
        {
            Id = id;
            DataOd = dataOd;
            DataDo = dataDo;
            IloscOsob = iloscOsob;
            CzyZameldowano = czyZameldowano;
            CzyWymeldowano = czyWymeldowano;
            Pokoj = pokoj;
            Osoba = osoba;
        }

        public int Id { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int IloscOsob { get; set; }
        public bool CzyZameldowano { get; set; }
        public bool CzyWymeldowano { get; set; }

        public Pokoj Pokoj { get; set; }

        public Osoba Osoba { get; set; }
    }
}