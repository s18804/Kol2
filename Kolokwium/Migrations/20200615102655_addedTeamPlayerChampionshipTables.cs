using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class addedTeamPlayerChampionshipTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    IdChampionship = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(maxLength: 100, nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.IdChampionship);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(maxLength: 30, nullable: false),
                    MaxAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.IdTeam);
                });

            migrationBuilder.InsertData(
                table: "Championship",
                columns: new[] { "IdChampionship", "OfficialName", "Year" },
                values: new object[] { 1, "mistrzostwo", 2020 });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "IdPlayer", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1999, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "Pierzchala" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "IdTeam", "MaxAge", "TeamName" },
                values: new object[] { 1, 20, "hulaho" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
