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
        private readonly IPeopleRepository _osobyRepository;

        public OsobaService(IPeopleRepository osobyRepository)
        {
            _osobyRepository = osobyRepository;
        }

        public async Task DodajOsobe(Person osoba)
        {
            await _osobyRepository.AddPerson(osoba);
        }

        public void Logowanie()
        {
            throw new NotImplementedException();
        }

        public void UsunKonto()
        {
            throw new NotImplementedException();
        }

        public void ZmianaEmail()
        {
            throw new NotImplementedException();
        }

        public void ZmianaHasla()
        {
            throw new NotImplementedException();
        }

        public void ZmianaImienia()
        {
            throw new NotImplementedException();
        }

        public void ZmianaNazwiskoa()
        {
            throw new NotImplementedException();
        }

        public void ZmianaTel()
        {
            throw new NotImplementedException();
        }
    }
}