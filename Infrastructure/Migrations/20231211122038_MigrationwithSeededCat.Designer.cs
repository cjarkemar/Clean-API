﻿// <auto-generated />
using System;
using Infrastructure.Database.RealDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    [Migration("20231211122038_MigrationwithSeededCat")]
    partial class MigrationwithSeededCat
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d4cf10c-346d-410e-afee-cde457a175c9"),
                            LikesToPlay = true,
                            Name = "Garfield"
                        },
                        new
                        {
                            Id = new Guid("f4aaa6b9-83da-45d7-8ba5-bdcddee1f59c"),
                            LikesToPlay = false,
                            Name = "HorseCatDude"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345674"),
                            LikesToPlay = true,
                            Name = "AmandatheUglyCat"
                        });
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
                            Id = new Guid("fab54d3b-95c9-4f6b-9473-4c49f66d8e2b"),
                            Name = "OldG"
                        },
                        new
                        {
                            Id = new Guid("86efbf16-6bc9-4a80-aae9-16e8af80fa59"),
                            Name = "NewG"
                        },
                        new
                        {
                            Id = new Guid("44d7e23f-0ff0-4e9d-a55b-1aa94118bd51"),
                            Name = "Björn"
                        },
                        new
                        {
                            Id = new Guid("0e03e9fa-722a-4aef-a180-f0d5e2c7dd73"),
                            Name = "Patrik"
                        },
                        new
                        {
                            Id = new Guid("55224cac-b05a-4c29-af05-fc3fe0324b46"),
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