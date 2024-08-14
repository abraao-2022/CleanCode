using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCode.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    width = table.Column<double>(type: "REAL", nullable: false),
                    height = table.Column<double>(type: "REAL", nullable: false),
                    length = table.Column<double>(type: "REAL", nullable: false),
                    weight = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_item", x => x.IdItem);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
