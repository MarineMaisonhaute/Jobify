using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobify.Migrations
{
    public partial class ResponsesBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Post_PostId1",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_PostId1",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Response");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "Response",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Response_PostId1",
                table: "Response",
                column: "PostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Post_PostId1",
                table: "Response",
                column: "PostId1",
                principalTable: "Post",
                principalColumn: "PostId");
        }
    }
}
