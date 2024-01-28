using Hotel.Application.Services.Rezerwacja;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections;
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

		public async Task<IEnumerable<Hotel.Domain.Entities.Rezerwacja>> PokazWszystkieRezerwacje()
		{
			var rezerwacje = await _rezerwacjeRepository.ZwrocWszystkieRezerwacje();

			var rezerwacjeList = rezerwacje.ToList();

			return rezerwacjeList;
		}

		public async Task<Domain.Entities.Rezerwacja?> WyszukajPoId(int id)
		{
			return await _rezerwacjeRepository.WyszukajPoId(id);
		}

		public void ZmianaDanychRezerwacjiUz()
		{
			throw new NotImplementedException();
		}

		public List<Hotel.Domain.Entities.Rezerwacja> PokazHistorieRezerwacji()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Domain.Entities.Rezerwacja>> ZwrocZajetePokojIdWTermminie(DateTime dataOd, DateTime dataDo)
		{
			return await _rezerwacjeRepository.WyszukajWTermminie(dataOd, dataDo);
		}

		public async Task<List<int>>? WyszukajPokojIdWTermminie(DateTime dataOd, DateTime dataDo)
		{
			return await _rezerwacjeRepository.WyszukajPokojIdWTermminie(dataOd, dataDo);
		}
	}
}