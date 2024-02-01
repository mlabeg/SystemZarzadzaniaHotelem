using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
	public interface IRezerwacjeRepository
	{
		Task DodajRezerwacje(Reservation rezerwacja);

		public Task<bool> UsunRezerwacje(int id);

		Task<IEnumerable<Reservation>> ZwrocWszystkie(string? wybor);

		Task<Reservation?> WyszukajPoId(int id);

		public Task<IEnumerable<Reservation>> WyszukajWTermminie(DateTime dataOd, DateTime dataDo);

		public Task<List<int>>? WyszukajPokojIdWTermminie(DateTime dataOd, DateTime dataDo);
	}
}