using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twitter_contest_dotnet.Migrations
{
    public partial class DuelMistakes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duel_Tweeter_UserProposalTweeterId",
                table: "Duel");

            migrationBuilder.DropColumn(
                name: "DuelId",
                table: "Duel");

            migrationBuilder.AlterColumn<string>(
                name: "UserProposalTweeterId",
                table: "Duel",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Duel_Tweeter_UserProposalTweeterId",
                table: "Duel",
                column: "UserProposalTweeterId",
                principalTable: "Tweeter",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duel_Tweeter_UserProposalTweeterId",
                table: "Duel");

            migrationBuilder.AlterColumn<string>(
                name: "UserProposalTweeterId",
                table: "Duel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DuelId",
                table: "Duel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Duel_Tweeter_UserProposalTweeterId",
                table: "Duel",
                column: "UserProposalTweeterId",
                principalTable: "Tweeter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
