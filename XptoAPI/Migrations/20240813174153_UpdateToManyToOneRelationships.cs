using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XptoAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToManyToOneRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_serviceOrders_ClientId",
                table: "serviceOrders");

            migrationBuilder.DropIndex(
                name: "IX_serviceOrders_ServiceExecuterId",
                table: "serviceOrders");

            migrationBuilder.CreateIndex(
                name: "IX_serviceOrders_ClientId",
                table: "serviceOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceOrders_ServiceExecuterId",
                table: "serviceOrders",
                column: "ServiceExecuterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_serviceOrders_ClientId",
                table: "serviceOrders");

            migrationBuilder.DropIndex(
                name: "IX_serviceOrders_ServiceExecuterId",
                table: "serviceOrders");

            migrationBuilder.CreateIndex(
                name: "IX_serviceOrders_ClientId",
                table: "serviceOrders",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_serviceOrders_ServiceExecuterId",
                table: "serviceOrders",
                column: "ServiceExecuterId",
                unique: true);
        }
    }
}
