using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddreceiptProductstocontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProduct_Product_ProductId",
                table: "ReceiptProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProduct_Receipt_ReceiptId",
                table: "ReceiptProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptProduct",
                table: "ReceiptProduct");

            migrationBuilder.RenameTable(
                name: "ReceiptProduct",
                newName: "ReceiptProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptProduct_ReceiptId",
                table: "ReceiptProducts",
                newName: "IX_ReceiptProducts_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptProduct_ProductId",
                table: "ReceiptProducts",
                newName: "IX_ReceiptProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptProducts",
                table: "ReceiptProducts",
                column: "ReceiptProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProducts_Product_ProductId",
                table: "ReceiptProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProducts_Receipt_ReceiptId",
                table: "ReceiptProducts",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "receipt_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProducts_Product_ProductId",
                table: "ReceiptProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProducts_Receipt_ReceiptId",
                table: "ReceiptProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptProducts",
                table: "ReceiptProducts");

            migrationBuilder.RenameTable(
                name: "ReceiptProducts",
                newName: "ReceiptProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptProducts_ReceiptId",
                table: "ReceiptProduct",
                newName: "IX_ReceiptProduct_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptProducts_ProductId",
                table: "ReceiptProduct",
                newName: "IX_ReceiptProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptProduct",
                table: "ReceiptProduct",
                column: "ReceiptProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProduct_Product_ProductId",
                table: "ReceiptProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProduct_Receipt_ReceiptId",
                table: "ReceiptProduct",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "receipt_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
