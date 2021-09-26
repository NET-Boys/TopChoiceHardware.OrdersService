using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopChoiceHardware.OrdersService.AccessData.Migrations
{
    public partial class migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenProducto",
                columns: table => new
                {
                    OrdenProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenProducto", x => x.OrdenProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    OrdenProductoId = table.Column<int>(type: "int", nullable: true),
                    OrdenProductoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Orden_MetodoPago_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "MetodoPago",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_OrdenProducto_OrdenProductoId",
                        column: x => x.OrdenProductoId,
                        principalTable: "OrdenProducto",
                        principalColumn: "OrdenProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_OrdenProducto_OrdenProductoId1",
                        column: x => x.OrdenProductoId1,
                        principalTable: "OrdenProducto",
                        principalColumn: "OrdenProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Factura_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Orden_UserId",
                        column: x => x.UserId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_OrdenId",
                table: "Factura",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_UserId",
                table: "Factura",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_OrdenProductoId",
                table: "Orden",
                column: "OrdenProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_OrdenProductoId1",
                table: "Orden",
                column: "OrdenProductoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_PaymentMethodId",
                table: "Orden",
                column: "PaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "OrdenProducto");
        }
    }
}
