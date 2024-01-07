using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Seeders
{
    public class HotelSeeder
    {
        //TODO dodać seedy klas Rezerwacja i Osoba
        private readonly HotelDbContext _dbContext;

        public HotelSeeder(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Pokoje.Any())
                {
                    var pokojSeed = new Pokoj()
                    {
                        Numer = 1,
                        LiczbaMiejsc = 2,
                        CzyWolny = true
                    };

                    _dbContext.Pokoje.Add(pokojSeed);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}