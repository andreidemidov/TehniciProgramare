using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_PROJECT_FreeLancePlatform_Api.Migrations
{
    public partial class changeColumnForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_UserModels_UserModelId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_UserModelId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Job");

            migrationBuilder.AddColumn<int>(
                name: "EmployeerId",
                table: "Job",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmployeerId",
                table: "Job",
                column: "EmployeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_UserModels_EmployeerId",
                table: "Job",
                column: "EmployeerId",
                principalTable: "UserModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_UserModels_EmployeerId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_EmployeerId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EmployeerId",
                table: "Job");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Job_UserModelId",
                table: "Job",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_UserModels_UserModelId",
                table: "Job",
                column: "UserModelId",
                principalTable: "UserModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
