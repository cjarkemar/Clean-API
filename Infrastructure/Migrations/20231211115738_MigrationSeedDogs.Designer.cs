﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    [Migration("20231211115738_MigrationSeedDogs")]
    partial class MigrationSeedDogs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Animal.Bird", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("CanFly")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("Domain.Models.Cat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8fd31c6d-d8ec-4076-9827-9ab87ea3f2a8"),
                            Name = "OldG"
                        },
                        new
                        {
                            Id = new Guid("b65865c3-05be-43bd-8b0e-111ba080bc06"),
                            Name = "NewG"
                        },
                        new
                        {
                            Id = new Guid("14147407-b8ab-420b-9daa-ed8f4ff767d5"),
                            Name = "Björn"
                        },
                        new
                        {
                            Id = new Guid("2ac91caf-916c-437e-a72b-3e70cdcccfbf"),
                            Name = "Patrik"
                        },
                        new
                        {
                            Id = new Guid("b0aa0043-d2df-4a05-945c-fc6dc0069c0a"),
                            Name = "Alfred"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345671"),
                            Name = "TestDogForUnitTests1"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345672"),
                            Name = "TestDogForUnitTests2"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345673"),
                            Name = "TestDogForUnitTests3"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345674"),
                            Name = "TestDogForUnitTests4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
