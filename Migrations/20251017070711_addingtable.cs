using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkExample.Migrations
{
    /// <inheritdoc />
    public partial class addingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_description",
                table: "Products",
                newName: "category");

            migrationBuilder.AddColumn<int>(
                name: "stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    annual_salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    years_experience = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropColumn(
                name: "stock",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Products",
                newName: "product_description");
        }
    }
}
