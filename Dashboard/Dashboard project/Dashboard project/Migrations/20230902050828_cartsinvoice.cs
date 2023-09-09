using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard_project.Migrations
{
    /// <inheritdoc />
    public partial class cartsinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Invoice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "Invoice",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
