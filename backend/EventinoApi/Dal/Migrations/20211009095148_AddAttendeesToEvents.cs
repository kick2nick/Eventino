using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class AddAttendeesToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_HostId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventStartDate",
                table: "Events",
                newName: "StartDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "HostId",
                table: "Events",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    AttendeesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscribedEventsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.AttendeesId, x.SubscribedEventsId });
                    table.ForeignKey(
                        name: "FK_EventUser_AspNetUsers_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Events_SubscribedEventsId",
                        column: x => x.SubscribedEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_SubscribedEventsId",
                table: "EventUser",
                column: "SubscribedEventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_HostId",
                table: "Events",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_HostId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Events",
                newName: "EventStartDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "HostId",
                table: "Events",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_HostId",
                table: "Events",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
