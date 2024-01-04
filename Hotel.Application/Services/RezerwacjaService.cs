using Hotel.Domain.Entities;
using Hotel.Domain.Interefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal class RezerwacjaService : IRezerwacjaService
    {
        private readonly IRezerwacjeRepository _rezerwacjeRepository;

        public RezerwacjaService(IRezerwacjeRepository rezerwacjeRepository)
        {
            _rezerwacjeRepository = rezerwacjeRepository;
        }

        public async Task UtworzenieRezerwacjiUz(Rezerwacja rezerwacja)
        {
            await _rezerwacjeRepository.UtworzRezerwacje(rezerwacja);
        }

        public void SprawdzenieSzczegolowRezerwacji()
        {
            throw new NotImplementedException();
        }

        public void UsuniecieRezerwacjiUz()
        {
            throw new NotImplementedException();
        }

        public void ZmianaDanychRezerwacjiUz()
        {
            throw new NotImplementedException();
        }
    }
}