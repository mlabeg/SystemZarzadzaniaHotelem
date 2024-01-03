using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Pokoj
    {
        public int Id { get; set; }
        public int Numer { get; set; }
        public int LiczbaMiejsc { get; set; }
        public bool CzyWolny { get; set; }

        public Pokoj()
        {
            CzyWolny = true;
        }

        public Pokoj(int _numer, int _liczbaMiejsc)
        {
            Numer = _numer;
            LiczbaMiejsc = _liczbaMiejsc;
        }
    }
}