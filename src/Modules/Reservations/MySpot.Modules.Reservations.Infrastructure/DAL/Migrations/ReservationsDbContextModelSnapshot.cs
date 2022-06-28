﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySpot.Modules.Reservations.Infrastructure.DAL;

#nullable disable

namespace MySpot.Modules.Reservations.Infrastructure.DAL.Migrations
{
    [DbContext(typeof(ReservationsDbContext))]
    partial class ReservationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("reservations")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParkingSpotId")
                        .HasColumnType("char(36)");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("WeeklyReservationsId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WeeklyReservationsId");

                    b.ToTable("Reservations", "reservations");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", "reservations");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("Week")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("_jobTitle")
                        .HasColumnType("longtext")
                        .HasColumnName("JobTitle");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Week")
                        .IsUnique();

                    b.ToTable("WeeklyReservations", "reservations");
                });

            modelBuilder.Entity("MySpot.Shared.Infrastructure.Messaging.Outbox.InboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Inbox", "reservations");
                });

            modelBuilder.Entity("MySpot.Shared.Infrastructure.Messaging.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SentAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TraceId")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Outbox", "reservations");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.Reservation", b =>
                {
                    b.HasOne("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", null)
                        .WithMany("Reservations")
                        .HasForeignKey("WeeklyReservationsId");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", b =>
                {
                    b.HasOne("MySpot.Modules.Reservations.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}