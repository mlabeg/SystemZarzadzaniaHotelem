using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Repositories
{
    internal class PeopleRepository : Hotel.Domain.Interfaces.IPeopleRepository
    {
        private readonly HotelDbContext _dbContext;

        public PeopleRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPerson(Client osoba)
        {
            _dbContext.People.Add(osoba);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Client> GetByPhoneNumber(string phoneNumber)
        {
            return await _dbContext.People
                .FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
        }
    }
}