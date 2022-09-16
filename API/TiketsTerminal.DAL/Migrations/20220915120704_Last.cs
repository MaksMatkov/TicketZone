using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiketsTerminal.DAL.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "T_Room",
                newSchema: "fbd");

            migrationBuilder.RenameColumn(
                name: "SeatsCount",
                schema: "fbd",
                table: "T_Room",
                newName: "Seats_Count");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "fbd",
                table: "T_Room",
                newName: "PK_Film");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Room",
                schema: "fbd",
                table: "T_Room",
                column: "PK_Film");

            migrationBuilder.CreateTable(
                name: "T_Film_Viewing_Time",
                schema: "fbd",
                columns: table => new
                {
                    PK_Film_Viewing_Time = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FK_Film = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FK_Room = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Film_Viewing_Time", x => x.PK_Film_Viewing_Time);
                });

            migrationBuilder.CreateTable(
                name: "T_Ticket_Order",
                schema: "fbd",
                columns: table => new
                {
                    PK_Ticket_Order = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FK_User = table.Column<int>(type: "INTEGER", nullable: false),
                    FK_Film_Viewing_Time = table.Column<int>(type: "INTEGER", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Ticket_Order", x => x.PK_Ticket_Order);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Film_Viewing_Time",
                schema: "fbd");

            migrationBuilder.DropTable(
                name: "T_Ticket_Order",
                schema: "fbd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Room",
                schema: "fbd",
                table: "T_Room");

            migrationBuilder.RenameTable(
                name: "T_Room",
                schema: "fbd",
                newName: "Room");

            migrationBuilder.RenameColumn(
                name: "Seats_Count",
                table: "Room",
                newName: "SeatsCount");

            migrationBuilder.RenameColumn(
                name: "PK_Film",
                table: "Room",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "ID");
        }
    }
}
