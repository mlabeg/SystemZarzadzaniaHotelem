using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal class PokojService : IPokojService
    {
        private readonly IPokojeRepository _pokojeRepository;

        public PokojService(IPokojeRepository pokojeRepository)
        {
            _pokojeRepository = pokojeRepository;
        }

        public async Task DodajPokoj(Pokoj pokoj)
        {
            await _pokojeRepository.DodajPokoj(pokoj);
        }

        public Pokoj GetPokojByNumber(int number)
        {
            throw new NotImplementedException();
        }

        public void ZmienStatus()
        {
            throw new NotImplementedException();
        }
    }
}