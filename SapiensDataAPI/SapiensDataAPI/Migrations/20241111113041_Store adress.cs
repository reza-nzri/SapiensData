using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class Storeadress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Store__address_i__76969D2E",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "UQ__StoreAdd__071A9587EC1B4587",
                table: "StoreAddress");

            migrationBuilder.DropIndex(
                name: "IX_Store_address_id",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "Store");

            migrationBuilder.AlterColumn<string>(
                name: "address_type",
                table: "StoreAddress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "UQ__StoreAdd__071A9587EC1B4587",
                table: "StoreAddress",
                column: "address_type",
                unique: true,
                filter: "[address_type] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_category_id",
                table: "Product",
                column: "category_id",
                principalTable: "Category",
                principalColumn: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_category_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "UQ__StoreAdd__071A9587EC1B4587",
                table: "StoreAddress");

            migrationBuilder.DropIndex(
                name: "IX_Product_category_id",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "address_type",
                table: "StoreAddress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "Store",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ__StoreAdd__071A9587EC1B4587",
                table: "StoreAddress",
                column: "address_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_address_id",
                table: "Store",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Store__address_i__76969D2E",
                table: "Store",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "address_id");
        }
    }
}
