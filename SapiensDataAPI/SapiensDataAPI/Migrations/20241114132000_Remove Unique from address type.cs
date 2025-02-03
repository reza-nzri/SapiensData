using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniquefromaddresstype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__StoreAdd__071A9587EC1B4587",
                table: "StoreAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UQ__StoreAdd__071A9587EC1B4587",
                table: "StoreAddress",
                column: "address_type",
                unique: true,
                filter: "[address_type] IS NOT NULL");
        }
    }
}
