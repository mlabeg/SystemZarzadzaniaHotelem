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
        // public DbSet<Domain.Entities.Hotel> Hotels { get; set; } - to chyba wgl nie będzie potrzebne

        //public DbSet<Domain.Entities.Kierownik> Kierownicy { get; set; }// - to też nie wiem czy będzie potrzebne czy nie będzie tego zastępować encja Osoby

        // public DbSet<Domain.Entities.Pokoj> Pokoje { get; set; } - to powinno być dobrze, ale chcę tylko sprawdzic jak będzie działać ten DbContext

        public DbSet<Domain.Entities.Osoba> Osoby { get; set; }
        public DbSet<Domain.Entities.Rezerwacja> Rezerwacje { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HotelDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osoba>().HasKey(o => o.Id);
            modelBuilder.Entity<Pokoj>().HasKey(p => p.Numer);

            modelBuilder.Entity<Osoba>()
                .HasDiscriminator<string>("osoba_type")
                .HasValue<Pracownik>("pracownik")
                .HasValue<Kierownik>("kierownik")
                .HasValue<UzytkownikNiezarejestrowany>("uzytkowanikNiezarejestrowny")
                .HasValue<UzytkownikZarejestrowany>("uzytkownikZarejestrowany");
        }
    }
}