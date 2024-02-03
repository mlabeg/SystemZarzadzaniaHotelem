using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public interface IRoomService
    {
        Task AddRoom(Room pokoj);

        public Task<Room?> GetById(int number);

        //TODO zmień nazwę tej metody:
        public Task<bool> AnyRooms();

        public Task<IEnumerable<Room>> GetAll();

        public Task<IEnumerable<Room>> GetAvailable(IEnumerable<Domain.Entities.Reservation> rezerwacje, int iloscOsob);

        public Task<IEnumerable<Room>> GetAvailable(List<int> zarezerwowanePokojId, int iloscOsob);
    }
}