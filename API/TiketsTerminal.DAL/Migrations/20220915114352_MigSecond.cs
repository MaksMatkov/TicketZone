using Microsoft.EntityFrameworkCore.Migrations;

namespace TiketsTerminal.DAL.Migrations
{
    public partial class MigSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PK_User_Data",
                schema: "fbd",
                table: "T_User",
                newName: "PK_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PK_User",
                schema: "fbd",
                table: "T_User",
                newName: "PK_User_Data");
        }
    }
}
