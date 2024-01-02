using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Hotel
    {
        //to chyba nie tak, tutaj cała baza danych będzie hotelem, czyli nie będzie takiej klasy jak "Hotel"

        public List<Pokoj> pokojList = new List<Pokoj>();
    }
}