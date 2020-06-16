using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class addedplayerTeamChampionshipTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship_Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false),
                    IdChampionship = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship_Team", x => new { x.IdTeam, x.IdChampionship });
                    table.ForeignKey(
                        name: "FK_Championship_Team_Championship_IdChampionship",
                        column: x => x.IdChampionship,
                        principalTable: "Championship",
                        principalColumn: "IdChampionship",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Championship_Team_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player_Team",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    NumOnShirt = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Team", x => new { x.IdPlayer, x.IdTeam });
                    table.ForeignKey(
                        name: "FK_Player_Team_Player_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Player",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Team_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Team_IdChampionship",
                table: "Championship_Team",
                column: "IdChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Team_IdTeam",
                table: "Player_Team",
                column: "IdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championship_Team");

            migrationBuilder.DropTable(
                name: "Player_Team");
        }
    }
}
