using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CanFly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LikesToPlay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Breed = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barks = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Breed = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BirdOwner",
                columns: table => new
                {
                    BirdId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdOwner", x => new { x.BirdId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BirdOwner_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BirdOwner_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatOwner",
                columns: table => new
                {
                    CatId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatOwner", x => new { x.CatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CatOwner_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatOwner_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DogOwner",
                columns: table => new
                {
                    DogId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogOwner", x => new { x.DogId, x.UserId });
                    table.ForeignKey(
                        name: "FK_DogOwner_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogOwner_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("109f2fe5-49b0-490b-92fd-b9140cd87bf0"), false, "Yellow", "Allanballan" },
                    { new Guid("2ea8167e-6cdf-44e8-b8dc-c5bc83c48c7d"), true, "Purple", "Cherry" },
                    { new Guid("42ef359d-8e78-4eb1-9d25-5a0adea10297"), true, "Green&Yellow", "TobiasNugget" },
                    { new Guid("e444b761-8b7c-4794-8fe8-fb6d71a44594"), false, "Black", "Kalle" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Breed", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("0b31f9b6-fbfa-4568-a3c3-13f3ae988984"), "Bergskatt", false, "HorseCatDude", 3 },
                    { new Guid("2fdfb4bb-bb20-4c00-962a-4f86fd6fc74c"), "Bergskatt", true, "Garfield", 3 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Barks", "Breed", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("0a9eca50-950f-4f6b-8f7d-b8c650050076"), true, "chihuahua", "Patrik", 4 },
                    { new Guid("1589368d-89d1-4946-824f-586556539a46"), false, "Labrador", "NewG", 15 },
                    { new Guid("825e70b9-3966-43e2-9b7b-a43b2f461914"), true, "Daschund", "Björn", 4 },
                    { new Guid("97dd46b6-fe8d-4c6a-ba50-15d23dba3e98"), true, "Golden Retriever", "OldG", 30 },
                    { new Guid("f40bf4a9-3165-431d-8f51-be0290a081d3"), true, "chihuahua", "Alfred", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirdOwner_UserId",
                table: "BirdOwner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatOwner_UserId",
                table: "CatOwner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DogOwner_UserId",
                table: "DogOwner",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirdOwner");

            migrationBuilder.DropTable(
                name: "CatOwner");

            migrationBuilder.DropTable(
                name: "DogOwner");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
