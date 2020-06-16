using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_PROJECT_FreeLancePlatform_Api.Migrations
{
    public partial class updateUserDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePayload",
                table: "UserDetail",
                newName: "SelectedFile");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "UserDetail",
                newName: "SelectedFileName");

            migrationBuilder.RenameColumn(
                name: "CurrentPosition",
                table: "UserDetail",
                newName: "Position");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelectedFileName",
                table: "UserDetail",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "SelectedFile",
                table: "UserDetail",
                newName: "FilePayload");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "UserDetail",
                newName: "CurrentPosition");
        }
    }
}
