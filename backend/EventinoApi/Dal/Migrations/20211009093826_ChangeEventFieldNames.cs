using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class ChangeEventFieldNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinAge",
                table: "Events",
                newName: "MinUserAge");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "Events",
                newName: "StartDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinUserAge",
                table: "Events",
                newName: "MinAge");

            migrationBuilder.RenameColumn(
                name: "EventStartDate",
                table: "Events",
                newName: "EventDate");
        }
    }
}
