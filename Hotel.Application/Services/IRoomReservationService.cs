using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public interface IRoomReservationService
    {
        public Task<IDictionary<Room, int>> CheckRoomsAvailabilityAsync(CheckAvailabilityModel query);
    }
}