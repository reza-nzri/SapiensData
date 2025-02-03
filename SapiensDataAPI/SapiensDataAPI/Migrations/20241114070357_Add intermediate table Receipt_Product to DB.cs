using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddintermediatetableReceipt_ProducttoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiptProduct",
                columns: table => new
                {
                    ReceiptProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptProduct", x => x.ReceiptProductId);
                    table.ForeignKey(
                        name: "FK_ReceiptProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptProduct_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "receipt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptProduct_ProductId",
                table: "ReceiptProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptProduct_ReceiptId",
                table: "ReceiptProduct",
                column: "ReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptProduct");
        }
    }
}
