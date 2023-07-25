using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryProject.DAL.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    basic_salary = table.Column<double>(type: "float", nullable: false),
                    attraction_right = table.Column<double>(type: "float", nullable: false),
                    commuting_right = table.Column<double>(type: "float", nullable: false),
                    overtime_amount = table.Column<double>(type: "float", nullable: false),
                    salary_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employees", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employees_first_name_last_name_salary_date",
                table: "tbl_employees",
                columns: new[] { "first_name", "last_name", "salary_date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_employees");
        }
    }
}
