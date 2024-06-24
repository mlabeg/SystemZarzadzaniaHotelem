using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System.Linq;

namespace Hotel.Application.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public async Task AddRoomAsync(Room pokoj)
        {
            await _roomsRepository.AddRoom(pokoj);
        }

        public async Task<bool> AnyRoomsAsync()
        {
            return await _roomsRepository.AnyRoom();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _roomsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _roomsRepository.GetAllAsync();
        }

        public async Task<IDictionary<Room, int>> GetAllDictAsync()
        {
            return ListToDictionary(await GetAllAsync());
        }

        public async Task<IDictionary<Room, int>> GetByCapacityDictAsync(int capacity)
        {
            return ListToDictionary(await _roomsRepository.GetByCapacityAsync(capacity));
        }

        public async Task<IEnumerable<Room>> GetAvailableAsync(IEnumerable<Hotel.Domain.Entities.Reservation> rezerwacje, int iloscOsob)
        {
            return await _roomsRepository.GetAvailable(rezerwacje, iloscOsob);
        }

        public async Task<IEnumerable<Room>> GetAvailableAsync(List<int> zarezerwowanePokojId, int iloscOsob)
        {
            return await _roomsRepository.GetAvailable(zarezerwowanePokojId, iloscOsob);
        }

        public async Task<IDictionary<Room, int>> GetAvailableDictAsync(List<int> zarezerwowanePokojId, int iloscOsob)
        {
            var roomsList = await _roomsRepository.GetAvailable(zarezerwowanePokojId, iloscOsob);

            return ListToDictionary(roomsList);
        }

        private IDictionary<Room, int> ListToDictionary(IEnumerable<Room>? rooms)
        {
            var roomsDict = new Dictionary<Room, int>();

            if (!rooms.Any())
            {
                return roomsDict;
            }

            foreach (var room in rooms)
            {
                if (roomsDict.Any(r => r.Key.TypeRoomId == room.TypeRoomId))
                {
                    var tmp = roomsDict.Keys.First(r => r.TypeRoomId == room.TypeRoomId);
                    roomsDict[tmp]++;
                }
                else
                {
                    roomsDict.Add(room, 1);
                }
            }

            return roomsDict;
        }
    }
}