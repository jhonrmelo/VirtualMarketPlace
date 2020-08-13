using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualMarketPlace.Repository.Migrations
{
    public partial class TypeCollaboratorCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_CategoryType_CollaboratorTypeId",
                table: "Collaborator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType");

            migrationBuilder.RenameTable(
                name: "CategoryType",
                newName: "CollaboratorType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaboratorType",
                table: "CollaboratorType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborator_CollaboratorType_CollaboratorTypeId",
                table: "Collaborator",
                column: "CollaboratorTypeId",
                principalTable: "CollaboratorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_CollaboratorType_CollaboratorTypeId",
                table: "Collaborator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaboratorType",
                table: "CollaboratorType");

            migrationBuilder.RenameTable(
                name: "CollaboratorType",
                newName: "CategoryType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborator_CategoryType_CollaboratorTypeId",
                table: "Collaborator",
                column: "CollaboratorTypeId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
