using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyBadgers.RestApi.Migrations
{
    public partial class ReportModyfication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "ReportGenreStatsModels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ReportGenreStatsModels",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "ReportGenreStatsModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ReportGenreStatsModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "GenreName",
                table: "ReportGenreStatsModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowsInDB",
                table: "ReportGenreStatsModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesInDB",
                table: "ReportGenreStatsModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportGenreStatsModels",
                table: "ReportGenreStatsModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportGenreStatsModels_Id",
                table: "ReportGenreStatsModels",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportGenreStatsModels",
                table: "ReportGenreStatsModels");

            migrationBuilder.DropIndex(
                name: "IX_ReportGenreStatsModels_Id",
                table: "ReportGenreStatsModels");

            migrationBuilder.DropColumn(
                name: "GenreName",
                table: "ReportGenreStatsModels");

            migrationBuilder.DropColumn(
                name: "RowsInDB",
                table: "ReportGenreStatsModels");

            migrationBuilder.DropColumn(
                name: "TimesInDB",
                table: "ReportGenreStatsModels");

            migrationBuilder.RenameTable(
                name: "ReportGenreStatsModels",
                newName: "Reports");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");
        }
    }
}
