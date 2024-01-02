using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal interface IRezerwacjaService
    {
        public void UtworzenieRezerwacjiUz();

        public void UsuniecieRezerwacjiUz();

        public void SprawdzenieSzczegolowRezerwacji();

        public void ZmianaDanychRezerwacjiUz();
    }
}