using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
	public interface IPokojService
	{
		Task DodajPokoj(Room pokoj);

		public Task<Room?> WyszukajPoId(int number);

		//TODO zmień nazwę tej metody:
		public Task<bool> PokojeAny();

		public Task<IEnumerable<Room>> ZwwrocWszystkie();

		public Task<IEnumerable<Room>> ZwrocDostepne(IEnumerable<Domain.Entities.Rezerwacja> rezerwacje, int iloscOsob);

		public Task<IEnumerable<Room>> ZwrocDostepne(List<int> zarezerwowanePokojId, int iloscOsob);
	}
}