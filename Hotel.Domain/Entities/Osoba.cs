using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public abstract class Osoba
    {
        public int Id { get; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NumerTelefonu { get; set; }
        public string AdresEmail { get; set; }

        public Osoba()
        {
        }

        public Osoba(int _id, string _imie, string _nazwisko, string _numerTelefonu, string _adresmail)
        {
            Id = _id;
            Imie = _imie;
            Nazwisko = _nazwisko;
            NumerTelefonu = _numerTelefonu;
            AdresEmail = _adresmail;
        }
    }
}