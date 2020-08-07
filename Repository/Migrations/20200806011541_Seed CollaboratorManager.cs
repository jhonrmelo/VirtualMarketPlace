using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualMarketPlace.Repository.Migrations
{
    public partial class SeedCollaboratorManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Collaborators",
                columns: new[] { "Id", "CollaboratorTypeId", "Email", "Name", "Password" },
                values: new object[] { 1, 1, "Manager@MarketPlace.com", "ManagerMarketPlace", "123@123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collaborators",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
