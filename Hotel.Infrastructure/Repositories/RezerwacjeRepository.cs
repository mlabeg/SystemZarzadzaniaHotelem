using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;

namespace Hotel.Infrastructure.Repositories
{
    internal class RezerwacjeRepository : Hotel.Domain.Interefaces.IRezerwacjeRepository
    {
        private readonly HotelDbContext _dbContext;

        public RezerwacjeRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UtworzRezerwacje(Rezerwacja rezerwacja)
        {
            _dbContext.Add(rezerwacja);
            await _dbContext.SaveChangesAsync();
        }
    }
}