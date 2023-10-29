using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExScheduler_Server.Migrations
{
    public partial class AddedDepartmentProgrammeSemesterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "programID",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "semesterID",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    departmentID = table.Column<Guid>(type: "uuid", nullable: false),
                    departmentName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.departmentID);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    semesterID = table.Column<Guid>(type: "uuid", nullable: false),
                    semesterName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.semesterID);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    programID = table.Column<Guid>(type: "uuid", nullable: false),
                    programName = table.Column<string>(type: "text", nullable: false),
                    departmentID = table.Column<Guid>(type: "uuid", nullable: false),
                    semesterID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.programID);
                    table.ForeignKey(
                        name: "FK_Programs_Departments_departmentID",
                        column: x => x.departmentID,
                        principalTable: "Departments",
                        principalColumn: "departmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programs_Semesters_semesterID",
                        column: x => x.semesterID,
                        principalTable: "Semesters",
                        principalColumn: "semesterID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_programID",
                table: "Students",
                column: "programID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_semesterID",
                table: "Students",
                column: "semesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_departmentID",
                table: "Programs",
                column: "departmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_semesterID",
                table: "Programs",
                column: "semesterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programs_programID",
                table: "Students",
                column: "programID",
                principalTable: "Programs",
                principalColumn: "programID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Semesters_semesterID",
                table: "Students",
                column: "semesterID",
                principalTable: "Semesters",
                principalColumn: "semesterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programs_programID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Semesters_semesterID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Students_programID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_semesterID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "programID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "semesterID",
                table: "Students");
        }
    }
}
