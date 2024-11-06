using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class test123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "UserSession",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "UserRelationship",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId1",
                table: "UserRelationship",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "UserAddress",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Savings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Investments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Income",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId1",
                table: "Income",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Expense",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId1",
                table: "Expense",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Debt",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "BankAccount",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppLanguage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Snapchat",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tiktok",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_ApplicationUserModelId",
                table: "UserSession",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_ApplicationUserModelId",
                table: "UserRelationship",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_ApplicationUserModelId1",
                table: "UserRelationship",
                column: "ApplicationUserModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_ApplicationUserModelId",
                table: "UserAddress",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_ApplicationUserModelId",
                table: "Savings",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_ApplicationUserModelId",
                table: "Investments",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_ApplicationUserModelId",
                table: "Income",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_ApplicationUserModelId1",
                table: "Income",
                column: "ApplicationUserModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ApplicationUserModelId",
                table: "Expense",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ApplicationUserModelId1",
                table: "Expense",
                column: "ApplicationUserModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_ApplicationUserModelId",
                table: "Debt",
                column: "ApplicationUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_ApplicationUserModelId",
                table: "BankAccount",
                column: "ApplicationUserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_AspNetUsers_ApplicationUserModelId",
                table: "BankAccount",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_AspNetUsers_ApplicationUserModelId",
                table: "Debt",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserModelId",
                table: "Expense",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserModelId1",
                table: "Expense",
                column: "ApplicationUserModelId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserModelId",
                table: "Income",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserModelId1",
                table: "Income",
                column: "ApplicationUserModelId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_AspNetUsers_ApplicationUserModelId",
                table: "Investments",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_AspNetUsers_ApplicationUserModelId",
                table: "Savings",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AspNetUsers_ApplicationUserModelId",
                table: "UserAddress",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelationship_AspNetUsers_ApplicationUserModelId",
                table: "UserRelationship",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRelationship_AspNetUsers_ApplicationUserModelId1",
                table: "UserRelationship",
                column: "ApplicationUserModelId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSession_AspNetUsers_ApplicationUserModelId",
                table: "UserSession",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AspNetUsers_ApplicationUserModelId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Debt_AspNetUsers_ApplicationUserModelId",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserModelId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserModelId1",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserModelId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserModelId1",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_AspNetUsers_ApplicationUserModelId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_AspNetUsers_ApplicationUserModelId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AspNetUsers_ApplicationUserModelId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_AspNetUsers_ApplicationUserModelId",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_AspNetUsers_ApplicationUserModelId1",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSession_AspNetUsers_ApplicationUserModelId",
                table: "UserSession");

            migrationBuilder.DropIndex(
                name: "IX_UserSession_ApplicationUserModelId",
                table: "UserSession");

            migrationBuilder.DropIndex(
                name: "IX_UserRelationship_ApplicationUserModelId",
                table: "UserRelationship");

            migrationBuilder.DropIndex(
                name: "IX_UserRelationship_ApplicationUserModelId1",
                table: "UserRelationship");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_ApplicationUserModelId",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_Savings_ApplicationUserModelId",
                table: "Savings");

            migrationBuilder.DropIndex(
                name: "IX_Investments_ApplicationUserModelId",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Income_ApplicationUserModelId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_ApplicationUserModelId1",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Expense_ApplicationUserModelId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_ApplicationUserModelId1",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Debt_ApplicationUserModelId",
                table: "Debt");

            migrationBuilder.DropIndex(
                name: "IX_BankAccount_ApplicationUserModelId",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "UserRelationship");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId1",
                table: "UserRelationship");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId1",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId1",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "Debt");

            migrationBuilder.DropColumn(
                name: "ApplicationUserModelId",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "AppLanguage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Github",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Snapchat",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tiktok",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "AspNetUsers");
        }
    }
}
