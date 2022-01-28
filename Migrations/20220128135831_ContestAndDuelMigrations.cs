using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twitter_contest_dotnet.Migrations
{
    public partial class ContestAndDuelMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TweeterALikes = table.Column<int>(type: "int", nullable: false),
                    TweeterBLikes = table.Column<int>(type: "int", nullable: false),
                    DuelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResponseTweeterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalTweeterAId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalTweeterBId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserProposalTweeterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duel_Contest_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Duel_Tweeter_ProposalTweeterAId",
                        column: x => x.ProposalTweeterAId,
                        principalTable: "Tweeter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Duel_Tweeter_ProposalTweeterBId",
                        column: x => x.ProposalTweeterBId,
                        principalTable: "Tweeter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Duel_Tweeter_ResponseTweeterId",
                        column: x => x.ResponseTweeterId,
                        principalTable: "Tweeter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Duel_Tweeter_UserProposalTweeterId",
                        column: x => x.UserProposalTweeterId,
                        principalTable: "Tweeter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duel_ContestId",
                table: "Duel",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_Duel_ProposalTweeterAId",
                table: "Duel",
                column: "ProposalTweeterAId");

            migrationBuilder.CreateIndex(
                name: "IX_Duel_ProposalTweeterBId",
                table: "Duel",
                column: "ProposalTweeterBId");

            migrationBuilder.CreateIndex(
                name: "IX_Duel_ResponseTweeterId",
                table: "Duel",
                column: "ResponseTweeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Duel_UserProposalTweeterId",
                table: "Duel",
                column: "UserProposalTweeterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duel");

            migrationBuilder.DropTable(
                name: "Contest");
        }
    }
}
