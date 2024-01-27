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

		public async Task<bool> PokojeAny()
		{
			return await _pokojeRepository.PokojeAny();
		}

		public async Task<Pokoj?> WyszukajPoId(int id)
		{
			return await _pokojeRepository.WyszukajPoId(id);
		}

		public void ZmienStatus()
		{
			throw new NotImplementedException();
		}
	}
}