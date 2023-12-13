using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Testmedanvandare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("39c2dc23-1a27-4d14-9969-bf50f910560d"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("f63ee327-51c5-41e7-8882-959be726f123"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("036bba56-bac1-4e13-9a80-32249754581d"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("ea5cca81-25ce-4044-9380-d183718f13ca"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("2b8d2eee-bcfc-46cc-a48d-a7898002b2ba"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("5679fdba-5c41-4e09-b706-1be86c1200dc"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("77cb74a5-1cda-4409-8479-adf89d6e8a53"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("ab78ab3b-48e0-4dff-bbed-f69aa136d1e6"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("cea58755-e176-4c48-8444-23bfd6d648da"));

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("7d6be299-7a34-404d-9e6a-2afde73d9030"), true, "TwitterGod" },
                    { new Guid("a47beca2-5791-4e0a-b0cc-2d99415a25b9"), false, "TobiasNugget" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("ca361584-a242-415f-8bcb-fb1707861d27"), true, "Garfield" },
                    { new Guid("d61a575b-33ad-45e0-a846-792c65c8197c"), false, "HorseCatDude" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04d8d7c5-32df-4ca1-8ea3-700f89290638"), "Björn" },
                    { new Guid("1ee8441f-5dcd-4636-94d9-fcbad12549f2"), "NewG" },
                    { new Guid("8782dc97-de4b-4dea-96c4-bd9dcd0ef2f4"), "Patrik" },
                    { new Guid("a2d38508-8c93-4fbf-b00f-060f66455176"), "Alfred" },
                    { new Guid("aec200f2-7f32-4025-9826-140375921f99"), "OldG" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "Username" },
                values: new object[] { new Guid("f85335f3-af15-45f2-a860-16fd71692ee4"), "Testanvändare", "", "testanvändarnamn" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("7d6be299-7a34-404d-9e6a-2afde73d9030"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("a47beca2-5791-4e0a-b0cc-2d99415a25b9"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("ca361584-a242-415f-8bcb-fb1707861d27"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("d61a575b-33ad-45e0-a846-792c65c8197c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("04d8d7c5-32df-4ca1-8ea3-700f89290638"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("1ee8441f-5dcd-4636-94d9-fcbad12549f2"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("8782dc97-de4b-4dea-96c4-bd9dcd0ef2f4"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("a2d38508-8c93-4fbf-b00f-060f66455176"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("aec200f2-7f32-4025-9826-140375921f99"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f85335f3-af15-45f2-a860-16fd71692ee4"));

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("39c2dc23-1a27-4d14-9969-bf50f910560d"), true, "TwitterGod" },
                    { new Guid("f63ee327-51c5-41e7-8882-959be726f123"), false, "TobiasNugget" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("036bba56-bac1-4e13-9a80-32249754581d"), false, "HorseCatDude" },
                    { new Guid("ea5cca81-25ce-4044-9380-d183718f13ca"), true, "Garfield" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b8d2eee-bcfc-46cc-a48d-a7898002b2ba"), "Björn" },
                    { new Guid("5679fdba-5c41-4e09-b706-1be86c1200dc"), "OldG" },
                    { new Guid("77cb74a5-1cda-4409-8479-adf89d6e8a53"), "Alfred" },
                    { new Guid("ab78ab3b-48e0-4dff-bbed-f69aa136d1e6"), "Patrik" },
                    { new Guid("cea58755-e176-4c48-8444-23bfd6d648da"), "NewG" }
                });
        }
    }
}
