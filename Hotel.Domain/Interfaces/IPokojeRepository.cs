using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
	public interface IPokojeRepository
	{
		Task DodajPokoj(Pokoj pokoj);

		Task<Pokoj?> WyszukajPoId(int id);

		Task<bool> PokojeAny();

		Task<IEnumerable<Pokoj>> ZwrocWszystkie();

		public Task<IEnumerable<Pokoj>> ZwrocDostepne(IEnumerable<Rezerwacja> rezerwacje, int iloscOsob);
	}
}