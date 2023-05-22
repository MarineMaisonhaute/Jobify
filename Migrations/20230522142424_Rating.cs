using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobify.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PostId",
                table: "Rating",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Post_PostId",
                table: "Rating",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Post_PostId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_PostId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
