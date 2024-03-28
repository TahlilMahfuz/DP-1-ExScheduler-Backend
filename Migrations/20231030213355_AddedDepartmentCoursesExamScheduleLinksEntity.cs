using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExScheduler_Server.Migrations
{
    public partial class AddedDepartmentCoursesExamScheduleLinksEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    courseID = table.Column<Guid>(type: "uuid", nullable: false),
                    courseName = table.Column<string>(type: "text", nullable: false),
                    semesterID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.courseID);
                    table.ForeignKey(
                        name: "FK_Course_Semesters_semesterID",
                        column: x => x.semesterID,
                        principalTable: "Semesters",
                        principalColumn: "semesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    linkID = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.linkID);
                });

            migrationBuilder.CreateTable(
                name: "CourseLinks",
                columns: table => new
                {
                    coursescourseID = table.Column<Guid>(type: "uuid", nullable: false),
                    linkslinkID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLinks", x => new { x.coursescourseID, x.linkslinkID });
                    table.ForeignKey(
                        name: "FK_CourseLinks_Course_coursescourseID",
                        column: x => x.coursescourseID,
                        principalTable: "Course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseLinks_Links_linkslinkID",
                        column: x => x.linkslinkID,
                        principalTable: "Links",
                        principalColumn: "linkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_semesterID",
                table: "Course",
                column: "semesterID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLinks_linkslinkID",
                table: "CourseLinks",
                column: "linkslinkID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLinks");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
