using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyBadgers.RestApi.Migrations
{
    public partial class FixReportGenreStatsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Precents",
                table: "ReportGenreStatsModels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precents",
                table: "ReportGenreStatsModels");
        }
    }
}
