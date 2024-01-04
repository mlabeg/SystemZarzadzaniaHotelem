using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public interface IRezerwacjaService
    {
        Task UtworzenieRezerwacjiUz(Rezerwacja rezerwacja);

        public void UsuniecieRezerwacjiUz();

        public void SprawdzenieSzczegolowRezerwacji();

        public void ZmianaDanychRezerwacjiUz();
    }
}