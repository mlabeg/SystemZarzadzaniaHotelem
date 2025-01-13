using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Repositories
{
    internal class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelDbContext _dbContext;

        public RoomTypeRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoomType> GetById(int id)
        {
            return await _dbContext.RoomTypes.FirstOrDefaultAsync(t => t.IdRoomType == id);
        }
    }
}