using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationwithSeededCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("14147407-b8ab-420b-9daa-ed8f4ff767d5"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("2ac91caf-916c-437e-a72b-3e70cdcccfbf"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("8fd31c6d-d8ec-4076-9827-9ab87ea3f2a8"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("b0aa0043-d2df-4a05-945c-fc6dc0069c0a"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("b65865c3-05be-43bd-8b0e-111ba080bc06"));

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "AmandatheUglyCat" },
                    { new Guid("8d4cf10c-346d-410e-afee-cde457a175c9"), true, "Garfield" },
                    { new Guid("f4aaa6b9-83da-45d7-8ba5-bdcddee1f59c"), false, "HorseCatDude" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e03e9fa-722a-4aef-a180-f0d5e2c7dd73"), "Patrik" },
                    { new Guid("44d7e23f-0ff0-4e9d-a55b-1aa94118bd51"), "Björn" },
                    { new Guid("55224cac-b05a-4c29-af05-fc3fe0324b46"), "Alfred" },
                    { new Guid("86efbf16-6bc9-4a80-aae9-16e8af80fa59"), "NewG" },
                    { new Guid("fab54d3b-95c9-4f6b-9473-4c49f66d8e2b"), "OldG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345674"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("8d4cf10c-346d-410e-afee-cde457a175c9"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("f4aaa6b9-83da-45d7-8ba5-bdcddee1f59c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("0e03e9fa-722a-4aef-a180-f0d5e2c7dd73"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("44d7e23f-0ff0-4e9d-a55b-1aa94118bd51"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("55224cac-b05a-4c29-af05-fc3fe0324b46"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("86efbf16-6bc9-4a80-aae9-16e8af80fa59"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("fab54d3b-95c9-4f6b-9473-4c49f66d8e2b"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14147407-b8ab-420b-9daa-ed8f4ff767d5"), "Björn" },
                    { new Guid("2ac91caf-916c-437e-a72b-3e70cdcccfbf"), "Patrik" },
                    { new Guid("8fd31c6d-d8ec-4076-9827-9ab87ea3f2a8"), "OldG" },
                    { new Guid("b0aa0043-d2df-4a05-945c-fc6dc0069c0a"), "Alfred" },
                    { new Guid("b65865c3-05be-43bd-8b0e-111ba080bc06"), "NewG" }
                });
        }
    }
}
