using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceWebSite.Migrations
{
    /// <inheritdoc />
    public partial class database6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Products",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CartId",
                table: "Products",
                newName: "IX_Products_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Products",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ClientId",
                table: "Products",
                newName: "IX_Products_CartId");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
