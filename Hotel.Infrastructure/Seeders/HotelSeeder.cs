using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Seeders
{
    public class HotelSeeder
    {
        //TODO SEEDER dodać seedy klas Rezerwacja i Osoba
        private readonly HotelDbContext _dbContext;

        public HotelSeeder(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            await SeedRoomTypes();
            await SeedRooms();
            await SeedPerson();
            //await SeedReservation();
        }

        public async Task SeedRooms()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Rooms.Any())
                {
                    var roomSeedList = new List<Room>(){
                        new Room()
                        {
                            Number = 100,
                            Capacity = 2,
                            TypeRoomId = 1
                        },
                        new Room()
                        {
                            Number = 101,
                            Capacity = 2,
                            TypeRoomId = 1
                        },
                        new Room()
                        {
                            Number = 102,
                            Capacity = 2,
                            TypeRoomId = 1
                        },
                        new Room()
                        {
                            Number = 200,
                            Capacity = 3,
                            TypeRoomId = 2
                        },
                        new Room()
                        {
                            Number = 300,
                            Capacity = 4,
                            TypeRoomId = 3
                        },
                        new Room()
                        {
                            Number = 400,
                            Capacity = 5,
                            TypeRoomId = 4
                        },
                         new Room()
                        {
                            Number = 401,
                            Capacity = 5,
                            TypeRoomId = 4
                        },
                        new Room()
                        {
                            Number = 500,
                            Capacity = 6,
                            TypeRoomId = 5
                        }
                    };

                    _dbContext.Rooms.AddRange(roomSeedList);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task SeedRoomTypes()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.RoomTypes.Any())
                {
                    var roomTypeSeedList = new List<RoomType>(){
                        new RoomType()
                        {
                            NameRoomType="Twin Business",
                            Price=250
                        },
                        new RoomType()
                        {
                            NameRoomType="Premium Business",
                            Price=350
                        },
                        new RoomType()
                        {
                            NameRoomType="Double/Twin Prestige",
                            Price=350
                        },
                        new RoomType()
                        {
                            NameRoomType="Premium Prestige",
                            Price=500
                        },
                          new RoomType()
                        {
                            NameRoomType="Apartament Prezydencki",
                            Price=750
                        }
                    };

                    _dbContext.RoomTypes.AddRange(roomTypeSeedList);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task SeedPerson()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.People.Any())
                {
                    var personSeedList = new List<Person>()
                    {
                        new UserUnregistered()
                        {
                            Name="Seeder1",
                            Surname="Seeder1",
                            PhoneNumber="Seeder1",
                            EmailAddress="Seeder1",
                        },
                        new UserUnregistered()
                        {
                            Name="Seeder2",
                            Surname="Seeder2",
                            PhoneNumber="Seeder2",
                            EmailAddress="Seeder2",
                        }
                    };

                    _dbContext.People.AddRange(personSeedList);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task SeedReservation()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Reservations.Any())
                {
                    var reservationSeedList = new List<Reservation>()
                    {
                        new Reservation()
                        {
                            DateFrom=new DateTime(2024,7,1),
                            DateTo=new DateTime(2024,7,7),
                            NumberOfGuests=1,
                            CheckedIn=false,
                            CheckedOut=false,
                            PriceTotal=1500,
                            RoomId=1,
                            PersonId=1,
                            Status="Oczekujaca"
                        },
                        new Reservation()
                        {
                            DateFrom=new DateTime(2024,6,15),
                            DateTo=new DateTime(2024,6,17),
                            NumberOfGuests=3,
                            CheckedIn=false,
                            CheckedOut=false,
                            PriceTotal=700,
                            RoomId=4,
                            PersonId=2,
                            Status="Oczekujaca"
                        },
                        new Reservation()
                        {
                            DateFrom=new DateTime(2024,9,15),
                            DateTo=new DateTime(2024,9,22),
                            NumberOfGuests=5,
                            CheckedIn=false,
                            CheckedOut=false,
                            PriceTotal=3500,
                            RoomId=6,
                            PersonId=1,
                            Status="Oczekujaca"
                        }
                    };

                    _dbContext.Reservations.AddRange(reservationSeedList);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}