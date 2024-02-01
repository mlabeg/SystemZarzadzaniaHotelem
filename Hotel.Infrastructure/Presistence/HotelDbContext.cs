using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Presistence
{
	public class HotelDbContext : DbContext
	{
		public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
		{
		}

		public DbSet<Domain.Entities.Room> Pokoje { get; set; }
		public DbSet<Domain.Entities.Person> Osoby { get; set; }
		public DbSet<Domain.Entities.Reservation> Rezerwacje { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().HasKey(o => o.Id);

			modelBuilder.Entity<Person>()
				.HasDiscriminator<string>("osoba_type")
				.HasValue<Employee>("pracownik")
				.HasValue<Manager>("kierownik")
				.HasValue<UserUnregistered>("uzytkowanikNiezarejestrowny")
				.HasValue<UserRegistered>("uzytkownikZarejestrowany");

			modelBuilder.Entity<RoomType>().HasKey(k => k.IdRoomType);
		}
	}
}