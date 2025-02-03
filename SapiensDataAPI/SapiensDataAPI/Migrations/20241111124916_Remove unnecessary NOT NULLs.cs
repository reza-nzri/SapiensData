using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveunnecessaryNOTNULLs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__UserAddr__071A95874A01A788",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "UQ__CompanyA__071A9587B0D05465",
                table: "CompanyAddress");

            migrationBuilder.AlterColumn<string>(
                name: "address_type",
                table: "UserAddress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "address_type",
                table: "CompanyAddress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "UQ__UserAddr__071A95874A01A788",
                table: "UserAddress",
                column: "address_type",
                unique: true,
                filter: "[address_type] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__CompanyA__071A9587B0D05465",
                table: "CompanyAddress",
                column: "address_type",
                unique: true,
                filter: "[address_type] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__UserAddr__071A95874A01A788",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "UQ__CompanyA__071A9587B0D05465",
                table: "CompanyAddress");

            migrationBuilder.AlterColumn<string>(
                name: "address_type",
                table: "UserAddress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address_type",
                table: "CompanyAddress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ__UserAddr__071A95874A01A788",
                table: "UserAddress",
                column: "address_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__CompanyA__071A9587B0D05465",
                table: "CompanyAddress",
                column: "address_type",
                unique: true);
        }
    }
}
