using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_PROJECT_FreeLancePlatform_Api.Migrations
{
    public partial class UserApplicantsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "UserModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_JobId",
                table: "UserModels",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModels_Job_JobId",
                table: "UserModels",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModels_Job_JobId",
                table: "UserModels");

            migrationBuilder.DropIndex(
                name: "IX_UserModels_JobId",
                table: "UserModels");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "UserModels");
        }
    }
}
