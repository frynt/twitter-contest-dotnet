using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twitter_contest_dotnet.Migrations
{
    public partial class LinkedinUserIdString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LinkedinUserId",
                table: "Tweeter",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LinkedinUserId",
                table: "Tweeter",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
