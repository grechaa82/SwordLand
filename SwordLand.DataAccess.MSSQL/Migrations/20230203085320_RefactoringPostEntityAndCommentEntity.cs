using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwordLand.DataAccess.MSSQL.Migrations
{
    public partial class RefactoringPostEntityAndCommentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostId",
                table: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostEntityId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostEntityId",
                table: "Comment",
                column: "PostEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostEntityId",
                table: "Comment",
                column: "PostEntityId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostEntityId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostEntityId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PostEntityId",
                table: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
