using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmersRecord.Migrations
{
    public partial class tablefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_farmerModels_TableJoin_TableJoinId",
                table: "farmerModels");

            migrationBuilder.RenameColumn(
                name: "TableJoinId",
                table: "farmerModels",
                newName: "TablejoinId");

            migrationBuilder.RenameIndex(
                name: "IX_farmerModels_TableJoinId",
                table: "farmerModels",
                newName: "IX_farmerModels_TablejoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_farmerModels_TableJoin_TablejoinId",
                table: "farmerModels",
                column: "TablejoinId",
                principalTable: "TableJoin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_farmerModels_TableJoin_TablejoinId",
                table: "farmerModels");

            migrationBuilder.RenameColumn(
                name: "TablejoinId",
                table: "farmerModels",
                newName: "TableJoinId");

            migrationBuilder.RenameIndex(
                name: "IX_farmerModels_TablejoinId",
                table: "farmerModels",
                newName: "IX_farmerModels_TableJoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_farmerModels_TableJoin_TableJoinId",
                table: "farmerModels",
                column: "TableJoinId",
                principalTable: "TableJoin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
