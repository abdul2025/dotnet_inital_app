using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class onetomanyitemtocatogery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatogeryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Catogery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catogery", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Catogery",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electro" },
                    { 2, "Electro" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10,
                column: "CatogeryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CatogeryId",
                table: "Items",
                column: "CatogeryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Catogery_CatogeryId",
                table: "Items",
                column: "CatogeryId",
                principalTable: "Catogery",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Catogery_CatogeryId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Catogery");

            migrationBuilder.DropIndex(
                name: "IX_Items_CatogeryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CatogeryId",
                table: "Items");
        }
    }
}
