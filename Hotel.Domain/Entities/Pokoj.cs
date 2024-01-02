using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Pokoj
    {
        public int Numer { get; set; }//-jednocześnie Id pokoju
        public int LiczbaMiejsc { get; set; }
        public bool CzyWolny { get; set; }

        public Pokoj()
        {
        }

        public Pokoj(int _numer, int _liczbaMiejsc)
        {
            Numer = _numer;
            LiczbaMiejsc = _liczbaMiejsc;
            CzyWolny = true;
        }
    }
}