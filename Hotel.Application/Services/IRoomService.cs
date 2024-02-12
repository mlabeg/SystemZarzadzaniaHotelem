using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
	public interface IRoomService
	{
		Task AddRoomAsync(Room room);

		public Task<Room?> GetByIdAsync(int number);

		public Task<bool> AnyRoomsAsync();

		public Task<IEnumerable<Room>> GetAllAsync();

		public Task<IDictionary<Room, int>> GetAllDictAsync();

		public Task<IEnumerable<Room>> GetAvailableAsync(IEnumerable<Reservation> rezerwacje, int iloscOsob);

		public Task<IEnumerable<Room>> GetAvailableAsync(List<int> zarezerwowanePokojId, int iloscOsob);

		public Task<IDictionary<Room, int>> GetAvailableDictAsync(List<int> zarezerwowanePokojId, int iloscOsob);
	}
}