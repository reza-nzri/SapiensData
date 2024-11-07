using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class Removeforeignstouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AspNetUsers_ApplicationUserModelId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK__BankAccou__user___65370702",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Debt_AspNetUsers_ApplicationUserModelId",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK__Debt__creditor_u__4E53A1AA",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserModelId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserModelId1",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK__Expense__source___339FAB6E",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK__Expense__user_id__32AB8735",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserModelId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserModelId1",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK__Income__source_u__22751F6C",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK__Income__user_id__208CD6FA",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_AspNetUsers_ApplicationUserModelId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK__Investmen__loane__55F4C372",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_AspNetUsers_ApplicationUserModelId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK__Savings__user_id__43D61337",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AspNetUsers_ApplicationUserModelId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK__UserAddre__user___59FA5E80",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_AspNetUsers_ApplicationUserModelId",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_AspNetUsers_ApplicationUserModelId1",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK__UserRelat__relat__60A75C0F",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK__UserRelat__user___5FB337D6",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSession_AspNetUsers_ApplicationUserModelId",
                table: "UserSession");

            migrationBuilder.DropForeignKey(
                name: "FK__UserSessi__user___68487DD7",
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

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "UserSession",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserSession",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "UserRelationship",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "related_user_id",
                table: "UserRelationship",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "UserAddress",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserAddress",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Savings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Savings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "loaned_to_user_id",
                table: "Investments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Income",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "source_user_id",
                table: "Income",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Expense",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "source_user_id",
                table: "Expense",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "creditor_user_id",
                table: "Debt",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "BankAccount",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "BankAccount",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_User_UserId1",
                table: "BankAccount",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__BankAccou__user___65370702",
                table: "BankAccount",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_User_user_id",
                table: "Debt",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Debt__creditor_u__4E53A1AA",
                table: "Debt",
                column: "creditor_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
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
                name: "FK__Expense__source___339FAB6E",
                table: "Expense",
                column: "source_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Expense__user_id__32AB8735",
                table: "Expense",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK__Income__source_u__22751F6C",
                table: "Income",
                column: "source_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Income__user_id__208CD6FA",
                table: "Income",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_User_user_id",
                table: "Investments",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Investmen__loane__55F4C372",
                table: "Investments",
                column: "loaned_to_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_User_UserId1",
                table: "Savings",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Savings__user_id__43D61337",
                table: "Savings",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_User_UserId1",
                table: "UserAddress",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserAddre__user___59FA5E80",
                table: "UserAddress",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK__UserRelat__relat__60A75C0F",
                table: "UserRelationship",
                column: "related_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserRelat__user___5FB337D6",
                table: "UserRelationship",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSession_User_UserId1",
                table: "UserSession",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserSessi__user___68487DD7",
                table: "UserSession",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_User_UserId1",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK__BankAccou__user___65370702",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Debt_User_user_id",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK__Debt__creditor_u__4E53A1AA",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserId1",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserId2",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK__Expense__source___339FAB6E",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK__Expense__user_id__32AB8735",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_User_UserId1",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_User_UserId2",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK__Income__source_u__22751F6C",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK__Income__user_id__208CD6FA",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_User_user_id",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK__Investmen__loane__55F4C372",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_User_UserId1",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK__Savings__user_id__43D61337",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_User_UserId1",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK__UserAddre__user___59FA5E80",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_User_UserId1",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRelationship_User_UserId2",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK__UserRelat__relat__60A75C0F",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK__UserRelat__user___5FB337D6",
                table: "UserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSession_User_UserId1",
                table: "UserSession");

            migrationBuilder.DropForeignKey(
                name: "FK__UserSessi__user___68487DD7",
                table: "UserSession");

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

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "UserSession",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "UserSession",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "UserRelationship",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "related_user_id",
                table: "UserRelationship",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "UserAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "UserAddress",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Savings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Savings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "loaned_to_user_id",
                table: "Investments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Investments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Income",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "source_user_id",
                table: "Income",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Expense",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "source_user_id",
                table: "Expense",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "creditor_user_id",
                table: "Debt",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "Debt",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "BankAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserModelId",
                table: "BankAccount",
                type: "nvarchar(450)",
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
                name: "FK__BankAccou__user___65370702",
                table: "BankAccount",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_AspNetUsers_ApplicationUserModelId",
                table: "Debt",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Debt__creditor_u__4E53A1AA",
                table: "Debt",
                column: "creditor_user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK__Expense__source___339FAB6E",
                table: "Expense",
                column: "source_user_id",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Expense__user_id__32AB8735",
                table: "Expense",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id");

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
                name: "FK__Income__source_u__22751F6C",
                table: "Income",
                column: "source_user_id",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Income__user_id__208CD6FA",
                table: "Income",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_AspNetUsers_ApplicationUserModelId",
                table: "Investments",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Investmen__loane__55F4C372",
                table: "Investments",
                column: "loaned_to_user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_AspNetUsers_ApplicationUserModelId",
                table: "Savings",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Savings__user_id__43D61337",
                table: "Savings",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AspNetUsers_ApplicationUserModelId",
                table: "UserAddress",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserAddre__user___59FA5E80",
                table: "UserAddress",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id");

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
                name: "FK__UserRelat__relat__60A75C0F",
                table: "UserRelationship",
                column: "related_user_id",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserRelat__user___5FB337D6",
                table: "UserRelationship",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSession_AspNetUsers_ApplicationUserModelId",
                table: "UserSession",
                column: "ApplicationUserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserSessi__user___68487DD7",
                table: "UserSession",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id");
        }
    }
}
