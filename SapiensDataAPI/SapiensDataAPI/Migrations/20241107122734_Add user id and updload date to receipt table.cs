using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class Adduseridandupdloaddatetoreceipttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Receipt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Receipt",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_UserId",
                table: "Receipt",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_AspNetUsers_UserId",
                table: "Receipt",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_AspNetUsers_UserId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_UserId",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Receipt");
        }
    }
}
