using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualMarketPlace.Repository.Migrations
{
    public partial class SeedCollaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CollaboratorTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Manager" });

            migrationBuilder.InsertData(
                table: "CollaboratorTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollaboratorTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CollaboratorTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
