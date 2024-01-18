using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Pokoj
    {
        //nie wiem czy przez to nie trzeba będzie dodać nowej tabeli

        public enum PokojTyp
        {
            //https://www.hotelgdansk.com.pl/nasze-pokoje

            Double_Twin_Prestige,
            Premium_Prestige,
            Apartament_Prezydencki,
            Twin_Business,
            Apartament_Yachting
        }

        public PokojTyp? TypPokoju { get; set; }

        public int Id { get; set; }
        public int Numer { get; set; }
        public int LiczbaMiejsc { get; set; }
        public int CenaZaNoc { get; set; }
        public string Opis { get; set; }

        public bool CzyWolny { get; set; }//chyba do wywalenia

        public Pokoj()
        {
            Opis = "";
            CzyWolny = true;
        }

        public Pokoj(int _numer, int _liczbaMiejsc)
        {
            Numer = _numer;
            LiczbaMiejsc = _liczbaMiejsc;
        }

        public Pokoj GetPokoj()
        {
            return this;
        }
    }
}