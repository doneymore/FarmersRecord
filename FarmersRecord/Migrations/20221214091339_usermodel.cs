using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmersRecord.Migrations
{
    public partial class usermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserModel",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "LastName", "Password", "TableJoinId" },
                values: new object[] { 1, "12345", "doneymore@123.com", "Nigeria", "NG", "12345", null });

            migrationBuilder.InsertData(
                table: "UserModel",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "LastName", "Password", "TableJoinId" },
                values: new object[] { 2, "12345!", "doneymore@123.com!", "Nigeria!", "NG!", "12345!", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserModel",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
