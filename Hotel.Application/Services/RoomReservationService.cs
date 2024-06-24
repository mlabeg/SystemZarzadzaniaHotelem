using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal class RoomReservationService : IRoomReservationService
    {
        private readonly IRoomService _roomService;
        private readonly IReservationService _reservationService;

        public RoomReservationService(IReservationService reservationService, IRoomService roomService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
        }

        public async Task<CheckAvailabilityModel> CheckRoomsAvailability(CheckAvailabilityModel query)
        {
            var resrvationsByDate = await _reservationService.GetByDateAsync(query.DateFrom, query.DateTo);

            IDictionary<Room, int> availableRooms = new Dictionary<Room, int>();

            if (!resrvationsByDate.Any())
            {
                availableRooms = await _roomService.GetByCapacityDictAsync(query.NumberOfGuests);
            }
            else
            {
                var zajetePokoje = resrvationsByDate.Select(r => r.RoomId).ToList();
                availableRooms = await _roomService.GetAvailableDictAsync(zajetePokoje, query.NumberOfGuests);
            }

            query.DictionayRooms = availableRooms;

            return query;
        }
    }
}