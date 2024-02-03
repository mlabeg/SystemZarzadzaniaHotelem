using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System.Linq;

namespace Hotel.Application.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRoomsRepository _pokojeRepository;

        public RoomService(IRoomsRepository pokojeRepository)
        {
            _pokojeRepository = pokojeRepository;
        }

        public async Task AddRoom(Room pokoj)
        {
            await _pokojeRepository.AddRoom(pokoj);
        }

        public async Task<bool> AnyRooms()
        {
            return await _pokojeRepository.AnyRoom();
        }

        public async Task<Room?> GetById(int id)
        {
            return await _pokojeRepository.GetById(id);
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _pokojeRepository.GetAll();
        }

        public async Task<IEnumerable<Room>> GetAvailable(IEnumerable<Hotel.Domain.Entities.Reservation> rezerwacje, int iloscOsob)
        {
            return await _pokojeRepository.GetAvailable(rezerwacje, iloscOsob);
        }

        public async Task<IEnumerable<Room>> GetAvailable(List<int> zarezerwowanePokojId, int iloscOsob)
        {
            return await _pokojeRepository.GetAvailable(zarezerwowanePokojId, iloscOsob);
        }

        public async Task<IDictionary<Room, int>> GetAvailableDict(List<int> zarezerwowanePokojId, int iloscOsob)
        {
            var roomsList = await _pokojeRepository.GetAvailable(zarezerwowanePokojId, iloscOsob);

            var roomsDict = new Dictionary<Room, int>();

            if (!roomsList.Any())
            {
                return roomsDict;
            }

            foreach (var room in roomsList)
            {
                if (roomsDict.Any(r => r.Key.TypeRoomId == room.TypeRoomId))
                {
                    var tmp = roomsDict.Keys.First(r => r.TypeRoomId == room.TypeRoomId);
                    roomsDict[tmp]++;
                }
                else
                {
                    roomsDict.Add(room, 0);
                }
            }

            return roomsDict;
        }
    }
}