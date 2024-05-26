﻿// <auto-generated />
using System;
using DreamParadise.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DreamParadise.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DreamParadise.Models.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RatingService")
                        .HasColumnType("int");

                    b.Property<string>("Suggestion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("RatingId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("DreamParadise.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdultsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ChildCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserWhoReservedUserId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("UserWhoReservedUserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("DreamParadise.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RatingUser", b =>
                {
                    b.Property<int>("UserRatingsRatingId")
                        .HasColumnType("int");

                    b.Property<int>("UserWhoRatedUserId")
                        .HasColumnType("int");

                    b.HasKey("UserRatingsRatingId", "UserWhoRatedUserId");

                    b.HasIndex("UserWhoRatedUserId");

                    b.ToTable("RatingUser");
                });

            modelBuilder.Entity("DreamParadise.Models.Reservation", b =>
                {
                    b.HasOne("DreamParadise.Models.User", "UserWhoReserved")
                        .WithMany("UserReservations")
                        .HasForeignKey("UserWhoReservedUserId");

                    b.Navigation("UserWhoReserved");
                });

            modelBuilder.Entity("RatingUser", b =>
                {
                    b.HasOne("DreamParadise.Models.Rating", null)
                        .WithMany()
                        .HasForeignKey("UserRatingsRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DreamParadise.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserWhoRatedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DreamParadise.Models.User", b =>
                {
                    b.Navigation("UserReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
