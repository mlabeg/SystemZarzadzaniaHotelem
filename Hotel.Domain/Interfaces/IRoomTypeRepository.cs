using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IRoomTypeRepository
    {
        public Task<RoomType> GetById(int id);
    }
}