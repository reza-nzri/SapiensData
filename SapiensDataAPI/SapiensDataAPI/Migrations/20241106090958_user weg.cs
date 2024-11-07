using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class Userweg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_User_UserId1",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Debt_User_user_id",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserId1",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserId2",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_User_UserId1",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_User_UserId2",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_User_user_id",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_User_UserId1",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_User_UserId1",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_User_UserId1",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_User_UserId2",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSession_User_UserId1",
                table: "UserSession");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_UserSession_UserId1",
                table: "UserSession");

            migrationBuilder.DropIndex(
                name: "IX_UserRelationship_UserId1",
                table: "UserRelationship");

            migrationBuilder.DropIndex(
                name: "IX_UserRelationship_UserId2",
                table: "UserRelationship");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_UserId1",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_Savings_UserId1",
                table: "Savings");

            migrationBuilder.DropIndex(
                name: "IX_Investments_user_id",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Income_UserId1",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_UserId2",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Expense_UserId1",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_UserId2",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Debt_user_id",
                table: "Debt");

            migrationBuilder.DropIndex(
                name: "IX_BankAccount_UserId1",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserRelationship");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "UserRelationship");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BankAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserSession",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserRelationship",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "UserRelationship",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserAddress",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Savings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Expense",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "Expense",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "BankAccount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    account_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    alt_emails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    app_language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "en"),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    company_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    facebook = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    github = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    instagram = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    job_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    last_login = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    linkedin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    prefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    profile_picture_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    recovery_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    recovery_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "[User]"),
                    snapchat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "active"),
                    suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    tiktok = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    twitter = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    youtube = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__B9BE370F03BB93CC", x => x.user_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserId1",
                table: "UserSession",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_UserId1",
                table: "UserRelationship",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_UserId2",
                table: "UserRelationship",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId1",
                table: "UserAddress",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_UserId1",
                table: "Savings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_user_id",
                table: "Investments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Income_UserId1",
                table: "Income",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Income_UserId2",
                table: "Income",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserId1",
                table: "Expense",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserId2",
                table: "Expense",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_user_id",
                table: "Debt",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_UserId1",
                table: "BankAccount",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "UQ__User__713342DDA1F6D29E",
                table: "User",
                column: "account_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__F3DBC5725409B28E",
                table: "User",
                column: "username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_User_UserId1",
                table: "BankAccount",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_User_user_id",
                table: "Debt",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_User_UserId1",
                table: "Expense",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_User_UserId2",
                table: "Expense",
                column: "UserId2",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_User_UserId1",
                table: "Income",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_User_UserId2",
                table: "Income",
                column: "UserId2",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_User_user_id",
                table: "Investments",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_User_UserId1",
                table: "Savings",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_User_UserId1",
                table: "UserAddress",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelationship_User_UserId1",
                table: "UserRelationship",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelationship_User_UserId2",
                table: "UserRelationship",
                column: "UserId2",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSession_User_UserId1",
                table: "UserSession",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");
        }
    }
}
