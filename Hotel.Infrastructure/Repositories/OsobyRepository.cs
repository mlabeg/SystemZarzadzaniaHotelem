using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Repositories
{
    internal class OsobyRepository : Hotel.Domain.Interfaces.IOsobyRepository
    {
        private readonly HotelDbContext _dbContext;

        public OsobyRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DodajOsobe(Person osoba)
        {
            _dbContext.Add(osoba);
            await _dbContext.SaveChangesAsync();
        }
    }
}