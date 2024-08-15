using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCode.Infra.Migrations
{
    /// <inheritdoc />
    public partial class novasTabelas : Migration
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
                name: "orders",
                columns: table => new
                {
                    IdOrder = table.Column<string>(type: "TEXT", nullable: false),
                    cpf = table.Column<string>(type: "TEXT", nullable: false),
                    coupon_code = table.Column<string>(type: "TEXT", nullable: true),
                    issue_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    freight = table.Column<double>(type: "REAL", nullable: false),
                    code = table.Column<string>(type: "TEXT", nullable: false),
                    sequence = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_order", x => x.IdOrder);
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
                    IdOrderItem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_item = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    quantity = table.Column<double>(type: "REAL", nullable: false),
                    OrderIdOrder = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_order_item", x => x.IdOrderItem);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "orders",
                        principalColumn: "IdOrder");
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderIdOrder",
                table: "orderItems",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_orders_coupon_code",
                table: "orders",
                column: "coupon_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "coupons");
        }
    }
}
