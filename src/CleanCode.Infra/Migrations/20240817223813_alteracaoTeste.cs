using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCode.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    percentage = table.Column<int>(type: "INTEGER", nullable: false),
                    expire_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cpf = table.Column<string>(type: "TEXT", nullable: false),
                    coupon_code = table.Column<string>(type: "TEXT", nullable: true),
                    issue_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    freight = table.Column<double>(type: "REAL", nullable: false),
                    code = table.Column<string>(type: "TEXT", nullable: true),
                    sequence = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_coupons_coupon_code",
                        column: x => x.coupon_code,
                        principalTable: "coupons",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    item_id = table.Column<int>(type: "INTEGER", nullable: false),
                    order_id = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    quantity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_order_id",
                table: "orderItems",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_coupon_code",
                table: "orders",
                column: "coupon_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "coupons");
        }
    }
}
