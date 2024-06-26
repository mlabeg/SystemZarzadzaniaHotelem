﻿using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
	public interface IRoomsRepository
	{
		Task AddRoom(Room pokoj);

		Task<Room?> GetByIdAsync(int id);

		Task<bool> AnyRoom();

		Task<IEnumerable<Room>> GetAllAsync();

		Task<IEnumerable<Room>> GetByCapacityAsync(int capacity);

		public Task<IEnumerable<Room>> GetAvailable(IEnumerable<Reservation> rezerwacje, int iloscOsob);

		public Task<IEnumerable<Room>> GetAvailable(List<int> zarezerwowanePokojId, int iloscOsob);
	}
}