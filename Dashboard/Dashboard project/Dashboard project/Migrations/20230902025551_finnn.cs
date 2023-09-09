using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard_project.Migrations
{
    /// <inheritdoc />
    public partial class finnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "QTY",
                table: "Invoice",
                newName: "Capacity");

            migrationBuilder.AlterColumn<string>(
                name: "CostumerId",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Invoice",
                newName: "QTY");

            migrationBuilder.AlterColumn<int>(
                name: "CostumerId",
                table: "Invoice",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
