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
		private readonly IRoomsRepository _pokojeRepository;

		public PokojService(IRoomsRepository pokojeRepository)
		{
			_pokojeRepository = pokojeRepository;
		}

		public async Task DodajPokoj(Room pokoj)
		{
			await _pokojeRepository.AddRoom(pokoj);
		}

		public async Task<bool> PokojeAny()
		{
			return await _pokojeRepository.AnyRoom();
		}

		public async Task<Room?> WyszukajPoId(int id)
		{
			return await _pokojeRepository.GetById(id);
		}

		public async Task<IEnumerable<Room>> ZwwrocWszystkie()
		{
			return await _pokojeRepository.GetAll();
		}

		public async Task<IEnumerable<Room>> ZwrocDostepne(IEnumerable<Hotel.Domain.Entities.Reservation> rezerwacje, int iloscOsob)
		{
			return await _pokojeRepository.GetAvailable(rezerwacje, iloscOsob);
		}

		public async Task<IEnumerable<Room>> ZwrocDostepne(List<int> zarezerwowanePokojId, int iloscOsob)
		{
			return await _pokojeRepository.GetAvailable(zarezerwowanePokojId, iloscOsob);
		}
	}
}