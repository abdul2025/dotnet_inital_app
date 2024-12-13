using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class M2MalteritemClien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemClient_Client_ItemId",
                table: "ItemClient");

            migrationBuilder.CreateIndex(
                name: "IX_ItemClient_ClientId",
                table: "ItemClient",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemClient_Client_ClientId",
                table: "ItemClient",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemClient_Client_ClientId",
                table: "ItemClient");

            migrationBuilder.DropIndex(
                name: "IX_ItemClient_ClientId",
                table: "ItemClient");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemClient_Client_ItemId",
                table: "ItemClient",
                column: "ItemId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
