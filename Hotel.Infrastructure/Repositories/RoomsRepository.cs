using Microsoft.Identity.Client.AuthScheme.PoP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Repositories
{
	public class RoomsRepository : Domain.Interfaces.IRoomsRepository
	{
		private readonly HotelDbContext _dbContext;

		public RoomsRepository(HotelDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddRoom(Room pokoj)
		{
			_dbContext.Add(pokoj);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> AnyRoom()
		{
			return await _dbContext.Rooms.AnyAsync();
		}

		public async Task<Room?> GetById(int id)
		{
			return await _dbContext.Rooms
				.Include(t => t.Type)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IEnumerable<Room>> GetAll()
		{
			return await _dbContext.Rooms.ToListAsync();
		}

		public async Task<IEnumerable<Room>> GetAvailable(IEnumerable<Reservation> rezerwacje, int iloscOsob)
		{
			var pokojePoIlosc = _dbContext.Rooms.Where(p => p.Capacity >= iloscOsob).AsAsyncEnumerable();

			var dostepnePokoje = await pokojePoIlosc.Where(p => !rezerwacje.Any(r => r.RoomId == p.Id)).ToListAsync();

			return dostepnePokoje;
		}

		public async Task<IEnumerable<Room>> GetAvailable(List<int> zarezerwowanePokojId, int iloscOsob)
		{
			return await _dbContext.Rooms
				.Where(p => p.Capacity >= iloscOsob)
				.Where(p => !zarezerwowanePokojId.Any(r => r.Equals(p.Id)))
				.ToListAsync();
		}
	}
}