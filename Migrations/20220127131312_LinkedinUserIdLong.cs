using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twitter_contest_dotnet.Migrations
{
    public partial class LinkedinUserIdLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LinkedinUserId",
                table: "Tweeter",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LinkedinUserId",
                table: "Tweeter",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
