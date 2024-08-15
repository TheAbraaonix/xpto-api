using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XptoAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingClientAndServiceExecuterModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "serviceExecuters",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Clients",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "serviceExecuters",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clients",
                newName: "Cnpj");
        }
    }
}
