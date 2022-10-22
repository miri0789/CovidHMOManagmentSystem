using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AlterClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationsClients_Clients_UserId",
                table: "VaccinationsClients");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "VaccinationsClients",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationsClients_UserId",
                table: "VaccinationsClients",
                newName: "IX_VaccinationsClients_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationsClients_Clients_ClientId",
                table: "VaccinationsClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationsClients_Clients_ClientId",
                table: "VaccinationsClients");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "VaccinationsClients",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationsClients_ClientId",
                table: "VaccinationsClients",
                newName: "IX_VaccinationsClients_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationsClients_Clients_UserId",
                table: "VaccinationsClients",
                column: "UserId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
