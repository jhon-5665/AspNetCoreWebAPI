using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registration = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Record = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Note = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Workload = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisiteId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplines_Disciplines_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disciplines_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsDisciplines",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplineId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Note = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDisciplines", x => new { x.StudentId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_StudentsDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsDisciplines_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Information Technology" },
                    { 2, "Information Systems" },
                    { 3, "Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "EndDate", "Name", "Registration", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marta", 1, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6208), "Kent", "33225555" },
                    { 2, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paula", 2, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6216), "Isabela", "3354288" },
                    { 3, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laura", 3, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6220), "Antonia", "55668899" },
                    { 4, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Luiza", 4, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6223), "Maria", "6565659" },
                    { 5, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lucas", 5, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6227), "Machado", "565685415" },
                    { 6, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pedro", 6, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6232), "Alvares", "456454545" },
                    { 7, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paulo", 7, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6236), "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "EndDate", "Name", "Record", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { 1, true, null, "Lauro", 1, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6015), "Oliveira", "" },
                    { 2, true, null, "Roberto", 2, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6027), "Soares", "" },
                    { 3, true, null, "Ronaldo", 3, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6028), "Marconi", "" },
                    { 4, true, null, "Rodrigo", 4, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6029), "Carvalho", "" },
                    { 5, true, null, "Alexandre", 5, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6030), "Montanha", "" }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[,]
                {
                    { 1, 1, "Math", null, 1, 0 },
                    { 2, 3, "Math", null, 1, 0 },
                    { 3, 3, "Physics", null, 2, 0 },
                    { 4, 1, "Portuguese", null, 3, 0 },
                    { 5, 1, "English", null, 4, 0 },
                    { 6, 2, "English", null, 4, 0 },
                    { 7, 3, "English", null, 4, 0 },
                    { 8, 1, "Programing", null, 5, 0 },
                    { 9, 2, "Programing", null, 5, 0 },
                    { 10, 3, "Programing", null, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentsDisciplines",
                columns: new[] { "DisciplineId", "StudentId", "EndDate", "Note", "StartDate" },
                values: new object[,]
                {
                    { 2, 1, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6256) },
                    { 4, 1, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6296) },
                    { 5, 1, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6297) },
                    { 1, 2, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6298) },
                    { 2, 2, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6299) },
                    { 5, 2, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6301) },
                    { 1, 3, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6301) },
                    { 2, 3, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6302) },
                    { 3, 3, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6303) },
                    { 1, 4, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6304) },
                    { 4, 4, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6305) },
                    { 5, 4, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6306) },
                    { 4, 5, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6307) },
                    { 5, 5, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6307) },
                    { 1, 6, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6308) },
                    { 2, 6, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6309) },
                    { 3, 6, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6309) },
                    { 4, 6, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6311) },
                    { 1, 7, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6312) },
                    { 2, 7, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6313) },
                    { 3, 7, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6314) },
                    { 4, 7, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6315) },
                    { 5, 7, null, null, new DateTime(2022, 12, 30, 17, 6, 52, 161, DateTimeKind.Local).AddTicks(6315) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_CourseId",
                table: "Disciplines",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_PrerequisiteId",
                table: "Disciplines",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDisciplines_DisciplineId",
                table: "StudentsDisciplines",
                column: "DisciplineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "StudentsDisciplines");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
