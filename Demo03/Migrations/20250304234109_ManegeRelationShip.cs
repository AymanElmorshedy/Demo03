using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Migrations
{
    /// <inheritdoc />
    public partial class ManegeRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManegerId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManegerId",
                table: "Departments",
                column: "ManegerId",
                unique: true,
                filter: "[ManegerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ManegerId",
                table: "Departments",
                column: "ManegerId",
                principalTable: "Employees",
                principalColumn: "ÈmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ManegerId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ManegerId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManegerId",
                table: "Departments");
        }
    }
}
