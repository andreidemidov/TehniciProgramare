using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_PROJECT_FreeLancePlatform_Api.Migrations
{
    public partial class CreateApplicantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    UserModelID = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => new { x.JobID, x.UserModelID });
                    table.ForeignKey(
                        name: "FK_Applicant_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applicant_UserModels_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "UserModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_UserModelID",
                table: "Applicant",
                column: "UserModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.CreateTable(
                name: "ParticipantModel",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false),
                    UserModelID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantModel", x => new { x.JobID, x.UserModelID });
                    table.ForeignKey(
                        name: "FK_ParticipantModel_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantModel_UserModels_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "UserModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantModel_UserModelID",
                table: "ParticipantModel",
                column: "UserModelID");
        }
    }
}
