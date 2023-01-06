using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmersRecord.Migrations
{
    public partial class dbinitializerjoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableJoinId",
                table: "farmerModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TableJoin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableJoin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableJoinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_TableJoin_TableJoinId",
                        column: x => x.TableJoinId,
                        principalTable: "TableJoin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_farmerModels_TableJoinId",
                table: "farmerModels",
                column: "TableJoinId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_TableJoinId",
                table: "UserModel",
                column: "TableJoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_farmerModels_TableJoin_TableJoinId",
                table: "farmerModels",
                column: "TableJoinId",
                principalTable: "TableJoin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_farmerModels_TableJoin_TableJoinId",
                table: "farmerModels");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "TableJoin");

            migrationBuilder.DropIndex(
                name: "IX_farmerModels_TableJoinId",
                table: "farmerModels");

            migrationBuilder.DropColumn(
                name: "TableJoinId",
                table: "farmerModels");
        }
    }
}
