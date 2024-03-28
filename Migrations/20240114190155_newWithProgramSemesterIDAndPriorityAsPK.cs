using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExScheduler_Server.Migrations
{
    public partial class newWithProgramSemesterIDAndPriorityAsPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkExamDates",
                table: "LinkExamDates");

            migrationBuilder.AddColumn<Guid>(
                name: "programSemesterID",
                table: "LinkExamDates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkExamDates",
                table: "LinkExamDates",
                columns: new[] { "LinkID", "ExamScheduleID", "Priority", "programSemesterID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkExamDates",
                table: "LinkExamDates");

            migrationBuilder.DropColumn(
                name: "programSemesterID",
                table: "LinkExamDates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkExamDates",
                table: "LinkExamDates",
                columns: new[] { "LinkID", "ExamScheduleID" });
        }
    }
}
