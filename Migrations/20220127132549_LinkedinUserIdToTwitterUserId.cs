using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twitter_contest_dotnet.Migrations
{
    public partial class LinkedinUserIdToTwitterUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedinUserId",
                table: "Tweeter",
                newName: "TwitterUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwitterUserId",
                table: "Tweeter",
                newName: "LinkedinUserId");
        }
    }
}
