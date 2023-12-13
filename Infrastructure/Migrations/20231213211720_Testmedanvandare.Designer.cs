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
    [Migration("20231213211720_Testmedanvandare")]
    partial class Testmedanvandare
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d6be299-7a34-404d-9e6a-2afde73d9030"),
                            CanFly = true,
                            Name = "TwitterGod"
                        },
                        new
                        {
                            Id = new Guid("a47beca2-5791-4e0a-b0cc-2d99415a25b9"),
                            CanFly = false,
                            Name = "TobiasNugget"
                        });
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
                            Id = new Guid("ca361584-a242-415f-8bcb-fb1707861d27"),
                            LikesToPlay = true,
                            Name = "Garfield"
                        },
                        new
                        {
                            Id = new Guid("d61a575b-33ad-45e0-a846-792c65c8197c"),
                            LikesToPlay = false,
                            Name = "HorseCatDude"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345675"),
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
                            Id = new Guid("aec200f2-7f32-4025-9826-140375921f99"),
                            Name = "OldG"
                        },
                        new
                        {
                            Id = new Guid("1ee8441f-5dcd-4636-94d9-fcbad12549f2"),
                            Name = "NewG"
                        },
                        new
                        {
                            Id = new Guid("04d8d7c5-32df-4ca1-8ea3-700f89290638"),
                            Name = "Björn"
                        },
                        new
                        {
                            Id = new Guid("8782dc97-de4b-4dea-96c4-bd9dcd0ef2f4"),
                            Name = "Patrik"
                        },
                        new
                        {
                            Id = new Guid("a2d38508-8c93-4fbf-b00f-060f66455176"),
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

            modelBuilder.Entity("Domain.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f85335f3-af15-45f2-a860-16fd71692ee4"),
                            Name = "Testanvändare",
                            PasswordHash = "",
                            Username = "testanvändarnamn"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
