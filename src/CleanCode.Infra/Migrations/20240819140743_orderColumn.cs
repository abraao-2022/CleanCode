using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCode.Infra.Migrations
{
    /// <inheritdoc />
    public partial class orderColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "total",
                table: "orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "orders");
        }
    }
}
