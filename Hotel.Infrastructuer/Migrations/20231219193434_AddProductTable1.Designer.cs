﻿// <auto-generated />
using System;
using Hotel.Infrastructuer.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Infrastructuer.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20231219193434_AddProductTable1")]
    partial class AddProductTable1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Domain.Entities.Account.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.AdvantageRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("ID");

                    b.ToTable("AdvantageRooms");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.AdvantageToRoom", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AdvantageId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AdvantageId");

                    b.HasIndex("AdvantageId");

                    b.ToTable("AdvantageToRooms");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EntryTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExitTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<int>("StageCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelAddress", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("HotelId");

                    b.ToTable("HotelAddresses");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelGallery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelGalleries");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<int>("Capecity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserCount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelRule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRules");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.ReserveRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<bool>("IsReserve")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReserveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("roomId");

                    b.ToTable("ReserveRooms");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Web.FirstBaner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("banerBotton")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("banerTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FirstBaners");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.AdvantageToRoom", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Product.AdvantageRoom", "AdvantageRoom")
                        .WithMany("AdvantageToRooms")
                        .HasForeignKey("AdvantageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Entities.Product.HotelRoom", "HotelRoom")
                        .WithMany("AdvantageToRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdvantageRoom");

                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelAddress", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Product.Hotel", "hetel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hetel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelGallery", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Product.Hotel", "hotel")
                        .WithMany("HotelGalleries")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelRoom", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Product.Hotel", "hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelRule", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Product.Hotel", "hotel")
                        .WithMany("HotelRules")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotel");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.ReserveRoom", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Product.HotelRoom", "HotelRoom")
                        .WithMany("reserveRooms")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.AdvantageRoom", b =>
                {
                    b.Navigation("AdvantageToRooms");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.Hotel", b =>
                {
                    b.Navigation("HotelGalleries");

                    b.Navigation("HotelRooms");

                    b.Navigation("HotelRules");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Product.HotelRoom", b =>
                {
                    b.Navigation("AdvantageToRooms");

                    b.Navigation("reserveRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
