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

        public DbSet<Domain.Entities.Pokoj> Pokoje { get; set; }
        public DbSet<Domain.Entities.Osoba> Osoby { get; set; }
        public DbSet<Domain.Entities.Rezerwacja> Rezerwacje { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osoba>().HasKey(o => o.Id);

            modelBuilder.Entity<Osoba>()
                .HasDiscriminator<string>("osoba_type")
                .HasValue<Pracownik>("pracownik")
                .HasValue<Kierownik>("kierownik")
                .HasValue<UzytkownikNiezarejestrowany>("uzytkowanikNiezarejestrowny")
                .HasValue<UzytkownikZarejestrowany>("uzytkownikZarejestrowany");
        }
    }
}