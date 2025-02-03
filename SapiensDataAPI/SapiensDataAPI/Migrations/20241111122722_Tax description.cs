using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class Taxdescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaxRate",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaxRate");
        }
    }
}
