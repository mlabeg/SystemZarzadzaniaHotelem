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
		public Task DodajRezerwacje(Domain.Entities.Rezerwacja rezerwacja);

		public Task<bool> UsunRezerwacje(int id);

		public Task<IEnumerable<Domain.Entities.Rezerwacja>> ZwrocWszystkie(string? wybor);

		public Task<Domain.Entities.Rezerwacja?> WyszukajPoId(int id);

		public Task<IEnumerable<Domain.Entities.Rezerwacja>> ZwrocRezerwacjeWTermminie(DateTime dataOd, DateTime dataDo);

		public Task<List<int>>? WyszukajPokojIdWTermminie(DateTime dataOd, DateTime dataDo);

		//TODO dodać poniższe
		//public List<Hotel.Domain.Entities.Rezerwacja> PokazHistorieRezerwacji();
		//public List<Hotel.Domain.Entities.Rezerwacja> PokazAktualneRezerwacje();
	}
}