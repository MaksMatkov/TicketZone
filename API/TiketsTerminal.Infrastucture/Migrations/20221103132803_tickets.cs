using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiketsTerminal.Infrastucture.Migrations
{
    public partial class tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fbd");

            migrationBuilder.CreateTable(
                name: "T_Film",
                schema: "fbd",
                columns: table => new
                {
                    PK_Film = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trailer_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Film", x => x.PK_Film);
                });

            migrationBuilder.CreateTable(
                name: "T_Room",
                schema: "fbd",
                columns: table => new
                {
                    PK_Film = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Seats_Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Room", x => x.PK_Film);
                });

            migrationBuilder.CreateTable(
                name: "T_User",
                schema: "fbd",
                columns: table => new
                {
                    PK_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Last_Visited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User", x => x.PK_User);
                });

            migrationBuilder.CreateTable(
                name: "T_Film_Viewing_Time",
                schema: "fbd",
                columns: table => new
                {
                    PK_Film_Viewing_Time = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Film = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_Room = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Film_Viewing_Time", x => x.PK_Film_Viewing_Time);
                    table.ForeignKey(
                        name: "FK_T_Film_Viewing_Time_T_Film_FK_Film",
                        column: x => x.FK_Film,
                        principalSchema: "fbd",
                        principalTable: "T_Film",
                        principalColumn: "PK_Film",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Film_Viewing_Time_T_Room_FK_Room",
                        column: x => x.FK_Room,
                        principalSchema: "fbd",
                        principalTable: "T_Room",
                        principalColumn: "PK_Film",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Ticket_Order",
                schema: "fbd",
                columns: table => new
                {
                    PK_Ticket_Order = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_User = table.Column<int>(type: "int", nullable: false),
                    FK_Film_Viewing_Time = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Ticket_Order", x => x.PK_Ticket_Order);
                    table.ForeignKey(
                        name: "FK_T_Ticket_Order_T_Film_Viewing_Time_FK_Film_Viewing_Time",
                        column: x => x.FK_Film_Viewing_Time,
                        principalSchema: "fbd",
                        principalTable: "T_Film_Viewing_Time",
                        principalColumn: "PK_Film_Viewing_Time",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Ticket_Order_T_User_FK_User",
                        column: x => x.FK_User,
                        principalSchema: "fbd",
                        principalTable: "T_User",
                        principalColumn: "PK_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Film_Viewing_Time_FK_Film",
                schema: "fbd",
                table: "T_Film_Viewing_Time",
                column: "FK_Film");

            migrationBuilder.CreateIndex(
                name: "IX_T_Film_Viewing_Time_FK_Room",
                schema: "fbd",
                table: "T_Film_Viewing_Time",
                column: "FK_Room");

            migrationBuilder.CreateIndex(
                name: "IX_T_Ticket_Order_FK_Film_Viewing_Time",
                schema: "fbd",
                table: "T_Ticket_Order",
                column: "FK_Film_Viewing_Time");

            migrationBuilder.CreateIndex(
                name: "IX_T_Ticket_Order_FK_User",
                schema: "fbd",
                table: "T_Ticket_Order",
                column: "FK_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Ticket_Order",
                schema: "fbd");

            migrationBuilder.DropTable(
                name: "T_Film_Viewing_Time",
                schema: "fbd");

            migrationBuilder.DropTable(
                name: "T_User",
                schema: "fbd");

            migrationBuilder.DropTable(
                name: "T_Film",
                schema: "fbd");

            migrationBuilder.DropTable(
                name: "T_Room",
                schema: "fbd");
        }
    }
}
