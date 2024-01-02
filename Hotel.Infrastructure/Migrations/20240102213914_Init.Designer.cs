﻿// <auto-generated />
using System;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Infrastructure.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20240102213914_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Numer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numer"));

                    b.Property<bool>("CzyWolny")
                        .HasColumnType("bit");

                    b.Property<int>("LiczbaMiejsc")
                        .HasColumnType("int");

                    b.HasKey("Numer");

                    b.ToTable("Pokoj");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Rezerwacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<int>("OsobaId")
                        .HasColumnType("int");

                    b.Property<int>("PokojNumer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OsobaId");

                    b.HasIndex("PokojNumer");

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
                        .HasForeignKey("OsobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Entities.Pokoj", "Pokoj")
                        .WithMany()
                        .HasForeignKey("PokojNumer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Osoba");

                    b.Navigation("Pokoj");
                });
#pragma warning restore 612, 618
        }
    }
}
