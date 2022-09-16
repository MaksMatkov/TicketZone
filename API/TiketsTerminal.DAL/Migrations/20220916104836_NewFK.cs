using Microsoft.EntityFrameworkCore.Migrations;

namespace TiketsTerminal.DAL.Migrations
{
    public partial class NewFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "fbd",
                table: "T_User",
                columns: new[] { "PK_User", "Email", "FK_Role", "Name", "Password" },
                values: new object[] { 1, "admin@admin.admin", 2, "ADMIN", "admin" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_T_Film_Viewing_Time_T_Film_FK_Film",
                schema: "fbd",
                table: "T_Film_Viewing_Time",
                column: "FK_Film",
                principalSchema: "fbd",
                principalTable: "T_Film",
                principalColumn: "PK_Film",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Film_Viewing_Time_T_Room_FK_Room",
                schema: "fbd",
                table: "T_Film_Viewing_Time",
                column: "FK_Room",
                principalSchema: "fbd",
                principalTable: "T_Room",
                principalColumn: "PK_Film",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Ticket_Order_T_Film_Viewing_Time_FK_Film_Viewing_Time",
                schema: "fbd",
                table: "T_Ticket_Order",
                column: "FK_Film_Viewing_Time",
                principalSchema: "fbd",
                principalTable: "T_Film_Viewing_Time",
                principalColumn: "PK_Film_Viewing_Time",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Ticket_Order_T_User_FK_User",
                schema: "fbd",
                table: "T_Ticket_Order",
                column: "FK_User",
                principalSchema: "fbd",
                principalTable: "T_User",
                principalColumn: "PK_User",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Film_Viewing_Time_T_Film_FK_Film",
                schema: "fbd",
                table: "T_Film_Viewing_Time");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Film_Viewing_Time_T_Room_FK_Room",
                schema: "fbd",
                table: "T_Film_Viewing_Time");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Ticket_Order_T_Film_Viewing_Time_FK_Film_Viewing_Time",
                schema: "fbd",
                table: "T_Ticket_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Ticket_Order_T_User_FK_User",
                schema: "fbd",
                table: "T_Ticket_Order");

            migrationBuilder.DropIndex(
                name: "IX_T_Ticket_Order_FK_Film_Viewing_Time",
                schema: "fbd",
                table: "T_Ticket_Order");

            migrationBuilder.DropIndex(
                name: "IX_T_Ticket_Order_FK_User",
                schema: "fbd",
                table: "T_Ticket_Order");

            migrationBuilder.DropIndex(
                name: "IX_T_Film_Viewing_Time_FK_Film",
                schema: "fbd",
                table: "T_Film_Viewing_Time");

            migrationBuilder.DropIndex(
                name: "IX_T_Film_Viewing_Time_FK_Room",
                schema: "fbd",
                table: "T_Film_Viewing_Time");

            migrationBuilder.DeleteData(
                schema: "fbd",
                table: "T_User",
                keyColumn: "PK_User",
                keyValue: 1);
        }
    }
}
