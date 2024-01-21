using Microsoft.Identity.Client.AuthScheme.PoP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;

namespace Hotel.Infrastructure.Repositories
{
    public class PokojeRepository : Hotel.Domain.Interfaces.IPokojeRepository
    {
        private readonly HotelDbContext _dbContext;

        public PokojeRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DodajPokoj(Pokoj pokoj)
        {
            _dbContext.Add(pokoj);
            await _dbContext.SaveChangesAsync();
        }
    }
}