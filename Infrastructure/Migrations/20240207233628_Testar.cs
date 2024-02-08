using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Testar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Dog_Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dog_Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authorized = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalUsers",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalUsers", x => x.Key);
                    table.ForeignKey(
                        name: "FK_AnimalUsers_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("0c2761ba-e3b7-4012-93f8-d73feb334d73"), "Labrador", "Dog", "Stanley", 6 },
                    { new Guid("1a9ab18c-8f85-41f9-b7c0-0adc426271e0"), "Labrador", "Dog", "Felix", 12 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("1aa35381-9577-4730-9647-2080e12193b4"), true, "Orange", "Bird", "Polly" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("1f538a9c-0b65-4476-8334-b7c083284a4c"), "Brittiskt korthår", "Cat", true, "Fred", 4 },
                    { new Guid("28d2c9ab-8681-4fe2-9126-0e6e9118fe5e"), "Perser", "Cat", true, "Charlie", 3 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("35986ab0-f95f-4113-a9ce-00a6b8bb8a54"), false, "Green", "Bird", "Apollo" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("512da4e1-ce86-423e-9471-7c240ed282f4"), "Siames", "Cat", true, "Jack", 3 },
                    { new Guid("575cd3aa-76c1-4a28-a33b-a29f4564bd29"), "Ragdoll", "Cat", false, "Signe", 4 },
                    { new Guid("59c83505-5403-481f-af0b-f1bb990551e3"), "Burma", "Cat", true, "Oscar", 4 },
                    { new Guid("6c7d4b8c-d6bd-4699-934e-431d4c9c3dfe"), "Bengal", "Cat", false, "Rose", 6 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("6caa7ed5-899d-4097-9ac9-e867a038b958"), "Boxer", "Dog", "Peppe", 8 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("7b2eb877-e944-4414-8049-a975e000c77b"), true, "Blue", "Bird", "Paulie" },
                    { new Guid("94af6d4c-a9b6-4fa0-a950-41bac5ad7eb4"), false, "Red", "Bird", "Ace" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("9a4746cc-0b47-450a-8b2f-fa0d288fd3fe"), "Boxer", "Dog", "Ludde", 9 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("9b34244c-a01e-47e4-84bb-c5179526a9f8"), "Burma", "Cat", true, "Mittens", 5 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("a1a24eaa-7570-42ee-872e-effd3256a403"), true, "Purple", "Bird", "Jay" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("ad9a7b30-5e24-4a2b-9a29-b4bc37e99b3f"), "Ragdoll", "Cat", false, "Molly", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("b0436532-b661-4e0b-a2dc-207b0ca8dcaf"), true, "Purple", "Bird", "Blue" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("b088ec7f-108d-4dbf-b0f0-4a1ff8373ba6"), "Golden retriever", "Dog", "Patrik", 13 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("b1f436c8-269f-45f4-829e-5982a9b66568"), false, "Yellow", "Bird", "Skye" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("b4531a2b-9a47-496b-95c0-60081522ec4a"), "Bulldog", "Dog", "NewG", 4 },
                    { new Guid("c8c10db4-6e41-47ab-abbd-928bbb12b3d4"), "Schäfer", "Dog", "Björn", 12 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("cc5a37a3-3ca0-42c5-bb7b-031c052e78a3"), false, "Red", "Bird", "Chip" },
                    { new Guid("d19790cc-9822-4d49-99c6-89441e0ea5e8"), true, "Yellow", "Bird", "Maverick" },
                    { new Guid("d1ca8cde-e71a-4e6c-bb4e-acd603e88a9a"), true, "Green", "Bird", "Daffy" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("db23e6d0-c8db-47eb-ab69-a9dd6edb8b7d"), "Labrador", "Dog", "OldG", 10 },
                    { new Guid("dd426c1c-31c9-4176-b578-b962fe6351b0"), "Pudel", "Dog", "Alfred", 6 },
                    { new Guid("dff4c9e5-f5ad-4749-abc8-9d35ce78afa7"), "Rottweiler", "Dog", "Rufus", 8 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("e6afd9fa-1aa8-4c6d-a4d8-5c3c94a97c31"), "Bengal", "Cat", true, "Simba", 6 },
                    { new Guid("f8d047a7-4127-49fd-8e67-9b1b6e9ed719"), "Perser", "Cat", false, "Tiger", 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("fcdae6bb-ce54-441a-9e82-9dbc32e438bc"), true, "admin", "admin", null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_AnimalId",
                table: "AnimalUsers",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_UserId",
                table: "AnimalUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalUsers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
