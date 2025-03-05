using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo03.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "DateOfCreation", "DeptName", "ManegerId" },
                values: new object[,]
                {
                    { 4, new DateOnly(2024, 12, 13), "Design", null },
                    { 5, new DateOnly(2024, 1, 13), "Sotware", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 5);
        }
    }
}
