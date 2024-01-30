﻿using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
	public interface IRezerwacjeRepository
	{
		Task DodajRezerwacje(Rezerwacja rezerwacja);

		public Task<bool> UsunRezerwacje(int id);

		Task<IEnumerable<Rezerwacja>> ZwrocWszystkie(string? wybor);

		Task<Rezerwacja?> WyszukajPoId(int id);

		public Task<IEnumerable<Rezerwacja>> WyszukajWTermminie(DateTime dataOd, DateTime dataDo);

		public Task<List<int>>? WyszukajPokojIdWTermminie(DateTime dataOd, DateTime dataDo);
	}
}