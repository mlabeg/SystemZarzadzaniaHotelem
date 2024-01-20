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
                        Numer = 100,
                        LiczbaMiejsc = 2,
                        //CzyWolny = true,
                        CenaZaNoc = 200
                    };

                    _dbContext.Pokoje.Add(pokojSeed);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}

//TODO Przenieść poniższe do seederay

/*

SET IDENTITY_INSERT dbo.pokoje ON;
  insert into dbo.Pokoje(Id,Numer,LiczbaMiejsc,CenaZaNoc,CzyWolny)
  VALUEs(2,105,5,500,1),
  (3,106,1,150, 1),
  (4,107,3,250, 1),
  (5,108,4,500, 1),
  (6,109,5,550, 1)
SET IDENTITY_INSERT dbo.pokoje OFF
*/