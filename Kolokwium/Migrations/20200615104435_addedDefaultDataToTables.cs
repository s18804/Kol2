using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class addedDefaultDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Championship_Team",
                columns: new[] { "IdTeam", "IdChampionship", "Score" },
                values: new object[] { 1, 1, 3.4f });

            migrationBuilder.InsertData(
                table: "Player_Team",
                columns: new[] { "IdPlayer", "IdTeam", "Comment", "NumOnShirt" },
                values: new object[] { 1, 1, null, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Championship_Team",
                keyColumns: new[] { "IdTeam", "IdChampionship" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Player_Team",
                keyColumns: new[] { "IdPlayer", "IdTeam" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
