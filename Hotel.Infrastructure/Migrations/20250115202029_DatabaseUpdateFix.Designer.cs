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
    [Migration("20250115202029_DatabaseUpdateFix")]
    partial class DatabaseUpdateFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preferences")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("osoba_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("osoba_type").HasValue("Client");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LiczbaPokoi")
                        .HasColumnType("int");

                    b.Property<string>("LokalizacjaHotelu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwaHotelu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.JobTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataRealizacji")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUtworzenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonelId")
                        .HasColumnType("int");

                    b.Property<string>("Priorytet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("PersonelId");

                    b.ToTable("JobTask");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataWyslania")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoscId")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypPowiadomienia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CheckedIn")
                        .HasColumnType("bit");

                    b.Property<bool>("CheckedOut")
                        .HasColumnType("bit");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<int>("PriceTotal")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeRoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TypeRoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.RoomType", b =>
                {
                    b.Property<int>("IdRoomType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRoomType"));

                    b.Property<string>("NameRoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("IdRoomType");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.UserUnregistered", b =>
                {
                    b.HasBaseType("Hotel.Domain.Entities.Client");

                    b.HasDiscriminator().HasValue("uzytkowanikNiezarejestrowny");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.UserRegistered", b =>
                {
                    b.HasBaseType("Hotel.Domain.Entities.UserUnregistered");

                    b.HasDiscriminator().HasValue("uzytkownikZarejestrowany");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Personel")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.JobTask", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Zadania")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Entities.Employee", "Personel")
                        .WithMany()
                        .HasForeignKey("PersonelId");

                    b.Navigation("Hotel");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Notification", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Client", "Client")
                        .WithMany("Notification")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.HasOne("Hotel.Domain.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Room", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Pokoje")
                        .HasForeignKey("HotelId");

                    b.HasOne("Hotel.Domain.Entities.RoomType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Client", b =>
                {
                    b.Navigation("Notification");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Personel");

                    b.Navigation("Pokoje");

                    b.Navigation("Zadania");
                });
#pragma warning restore 612, 618
        }
    }
}
