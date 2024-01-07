using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal class OsobaService : IOsobaService
    {
        private readonly IOsobyRepository _osobyRepository;

        public OsobaService(IOsobyRepository osobyRepository)
        {
            _osobyRepository = osobyRepository;
        }

        public async Task DodajOsobe(Osoba osoba)
        {
            await _osobyRepository.DodajOsobe(osoba);
        }
    }
}