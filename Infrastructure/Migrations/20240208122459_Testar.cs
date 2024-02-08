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
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("04966dde-285b-4687-932e-d4ae2d06cfba"), "Ragdoll", "Cat", false, "Signe", 4 },
                    { new Guid("054ca817-19bb-4133-a03e-524cd9e372af"), "Perser", "Cat", true, "Charlie", 3 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("103b423a-9ea0-4e8a-ae4b-4c3ada5c6cb7"), true, "Yellow", "Bird", "Maverick" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("22e95b1f-e16e-4723-8437-92a650db5eec"), "Pudel", "Dog", "Alfred", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("3ac8b69e-7e1c-4ad9-98c4-2d46511f9f87"), "Siames", "Cat", true, "Jack", 3 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("3f7a5ad2-1707-4b5d-bdef-115bc95a298b"), "Rottweiler", "Dog", "Rufus", 8 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("407e443f-1eca-403b-8609-779a35b51368"), false, "Yellow", "Bird", "Skye" },
                    { new Guid("4e8e50e5-8587-4c89-8f19-011e9c810f18"), true, "Purple", "Bird", "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("5a1ceb77-ad2f-41d4-80da-c59501674056"), "Bengal", "Cat", true, "Simba", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("5e5969fd-0a2b-41a8-9a96-58b8b616a007"), "Schäfer", "Dog", "Björn", 12 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("5ecc1266-e301-4eee-83d9-da86adc7c4ef"), false, "Green", "Bird", "Apollo" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("63bfd80d-ebc0-45b9-b0f2-9531411a4f09"), "Labrador", "Dog", "Felix", 12 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("64fd742c-4baf-4d86-a9f7-afed65dd7796"), true, "Green", "Bird", "Daffy" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("66278b9c-9710-4c69-96f5-e087581a4472"), "Labrador", "Dog", "Stanley", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("6cf7af72-ebdb-4374-99e6-4e621f5416b9"), true, "Purple", "Bird", "Jay" },
                    { new Guid("7bdab1b8-c0e8-436a-9090-2b250b13f3ad"), false, "Red", "Bird", "Ace" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("80e7fbe3-e82d-4c03-8cce-aef984f69497"), "Boxer", "Dog", "Peppe", 8 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("a414c39b-2067-49ef-9958-23bd9aa480b1"), "Bengal", "Cat", false, "Rose", 6 },
                    { new Guid("b46b42df-a055-475a-b5e0-cde15c5f3777"), "Brittiskt korthår", "Cat", true, "Fred", 4 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("b70d4b9d-38e2-4cfa-b79a-5385fb18019c"), true, "Orange", "Bird", "Polly" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("c0962cf6-53b7-4f4c-83ff-18095421b545"), "Burma", "Cat", true, "Mittens", 5 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("c168a5e4-e5e3-40ae-b90f-c1279c471949"), "Labrador", "Dog", "OldG", 10 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("c3ba763b-a5c9-4f4d-984e-ebb8a5e0e86b"), false, "Red", "Bird", "Chip" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("d375bade-4097-4c49-866d-66eeb34f716e"), "Burma", "Cat", true, "Oscar", 4 },
                    { new Guid("e031ea3a-296d-4f26-9638-1b79c0f9f461"), "Ragdoll", "Cat", false, "Molly", 6 },
                    { new Guid("e552a0f0-8154-4851-80b7-95fcb760f7ca"), "Perser", "Cat", false, "Tiger", 5 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("e555ef02-794d-4acb-8fb4-0915a841744f"), true, "Blue", "Bird", "Paulie" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("e635a129-8e70-46e8-9af4-55b1f9008ade"), "Bulldog", "Dog", "NewG", 4 },
                    { new Guid("e8e166d7-28ce-464c-aa14-24435ca17e2e"), "Boxer", "Dog", "Ludde", 9 },
                    { new Guid("f2639953-b64a-49b2-a5cb-c345fd242103"), "Golden retriever", "Dog", "Patrik", 13 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("a0e458c8-65e0-4558-b2fd-05e5d6b47f59"), true, "admin", "admin", null, "admin" }
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
