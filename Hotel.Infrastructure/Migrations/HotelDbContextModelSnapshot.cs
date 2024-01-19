﻿// <auto-generated />
using System;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Infrastructure.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Domain.Entities.Osoba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdresEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("osoba_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Osoby");

                    b.HasDiscriminator<string>("osoba_type").HasValue("Osoba");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Pokoj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CenaZaNoc")
                        .HasColumnType("int");

                    b.Property<bool>("CzyWolny")
                        .HasColumnType("bit");

                    b.Property<int>("LiczbaMiejsc")
                        .HasColumnType("int");

                    b.Property<int>("Numer")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypPokoju")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pokoje");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Rezerwacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CenaCalkowita")
                        .HasColumnType("int");

                    b.Property<bool>("CzyWymeldowano")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyZameldowano")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOd")
                        .HasColumnType("datetime2");

                    b.Property<int>("IloscOsob")
                        .HasColumnType("int");

                    b.Property<int?>("OsobaId")
                        .HasColumnType("int");

                    b.Property<int>("PokojId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OsobaId");

                    b.ToTable("Rezerwacje");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Pracownik", b =>
                {
                    b.HasBaseType("Hotel.Domain.Entities.Osoba");

                    b.Property<string>("Stanowisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("pracownik");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.UzytkownikNiezarejestrowany", b =>
                {
                    b.HasBaseType("Hotel.Domain.Entities.Osoba");

                    b.HasDiscriminator().HasValue("uzytkowanikNiezarejestrowny");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Kierownik", b =>
                {
                    b.HasBaseType("Hotel.Domain.Entities.Pracownik");

                    b.HasDiscriminator().HasValue("kierownik");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.UzytkownikZarejestrowany", b =>
                {
                    b.HasBaseType("Hotel.Domain.Entities.UzytkownikNiezarejestrowany");

                    b.HasDiscriminator().HasValue("uzytkownikZarejestrowany");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Rezerwacja", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Osoba", "Osoba")
                        .WithMany()
                        .HasForeignKey("OsobaId");

                    b.Navigation("Osoba");
                });
#pragma warning restore 612, 618
        }
    }
}
