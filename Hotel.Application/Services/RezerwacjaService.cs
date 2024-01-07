using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
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

        public async Task DodajRezerwacjeUz(Rezerwacja rezerwacja)
        {
            await _rezerwacjeRepository.DodajRezerwacje(rezerwacja);
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

        public List<Rezerwacja> PokazAktualneRezerwacje()
        {
            throw new NotImplementedException();
        }

        public List<Rezerwacja> PokazHistorieRezerwacji()
        {
            throw new NotImplementedException();
        }
    }
}