using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwordLand.DataAccess.MSSQL.Migrations
{
    public partial class AddedCategoryIDToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_CategoryId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Post",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId1",
                table: "Post",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category_CategoryId1",
                table: "Post",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category_CategoryId1",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_CategoryId1",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Post");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Post",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
