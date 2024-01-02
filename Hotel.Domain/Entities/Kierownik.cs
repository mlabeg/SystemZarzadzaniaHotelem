using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Kierownik : Pracownik
    {
        public Kierownik()
        { }

        public Kierownik(int _id, string _imie, string _nazwisko, string _numerTelefonu, string _adresmail)
            : base(_id, _imie, _nazwisko, _numerTelefonu, _adresmail)
        {
            Stanowisko = "Kierownik";
        }
    }
}