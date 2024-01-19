using Hotel.Application.Services.Rezerwacja;
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

		public async Task DodajRezerwacje(Domain.Entities.Rezerwacja rezerwacja)
		{
			await _rezerwacjeRepository.DodajRezerwacje(rezerwacja);
		}

		public async Task UsunRezerwacje(int id)
		{
			await _rezerwacjeRepository.UsunRezerwacje(id);
		}

		public void SprawdzenieSzczegolowRezerwacji()
		{
			throw new NotImplementedException();
		}

		public void ZmianaDanychRezerwacjiUz()
		{
			throw new NotImplementedException();
		}

		public List<Hotel.Domain.Entities.Rezerwacja> PokazAktualneRezerwacje()
		{
			throw new NotImplementedException();
		}

		public List<Hotel.Domain.Entities.Rezerwacja> PokazHistorieRezerwacji()
		{
			throw new NotImplementedException();
		}
	}
}