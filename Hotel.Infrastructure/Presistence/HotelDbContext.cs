using Hotel.Domain.Entities;
using Hotel.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public DbSet<Domain.Entities.Room> Rooms { get; set; }
        public DbSet<Domain.Entities.Client> Clients { get; set; }
        public DbSet<Domain.Entities.Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Domain.Entities.Hotel> Hotels { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<JobTask> JobTasks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(o => o.Id);

            modelBuilder.Entity<Client>()
                .HasDiscriminator<string>("osoba_type")
                .HasValue<UserUnregistered>("uzytkowanikNiezarejestrowny")
                .HasValue<UserRegistered>("uzytkownikZarejestrowany");

            modelBuilder.Entity<RoomType>().HasKey(k => k.IdRoomType);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Type)
                .WithMany()
                .HasForeignKey(t => t.TypeRoomId);
        }
    }
}