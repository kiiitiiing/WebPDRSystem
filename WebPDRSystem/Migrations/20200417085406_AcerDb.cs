using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPDRSystem.Migrations
{
    public partial class AcerDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PDRUsers_TeamSchedule",
                table: "PDRUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Team",
                table: "PDRUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "PDRUsers",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PDRUsers_UserTeams",
                table: "PDRUsers",
                column: "Team",
                principalTable: "UserTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PDRUsers_UserTeams",
                table: "PDRUsers");

            migrationBuilder.DropTable(
                name: "UserTeams");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "PDRUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Team",
                table: "PDRUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PDRUsers_TeamSchedule",
                table: "PDRUsers",
                column: "Team",
                principalTable: "TeamSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
