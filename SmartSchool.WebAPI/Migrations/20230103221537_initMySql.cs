using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initMySql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Record = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Workload = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentsDisciplines",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    { 1, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marta", 1, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3586), "Kent", "33225555" },
                    { 2, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paula", 2, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3601), "Isabela", "3354288" },
                    { 3, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laura", 3, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3609), "Antonia", "55668899" },
                    { 4, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Luiza", 4, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3615), "Maria", "6565659" },
                    { 5, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lucas", 5, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3623), "Machado", "565685415" },
                    { 6, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pedro", 6, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3631), "Alvares", "456454545" },
                    { 7, true, new DateTime(2005, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paulo", 7, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3639), "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "EndDate", "Name", "Record", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { 1, true, null, "Lauro", 1, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3344), "Oliveira", "" },
                    { 2, true, null, "Roberto", 2, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3363), "Soares", "" },
                    { 3, true, null, "Ronaldo", 3, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3365), "Marconi", "" },
                    { 4, true, null, "Rodrigo", 4, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3367), "Carvalho", "" },
                    { 5, true, null, "Alexandre", 5, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3368), "Montanha", "" }
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
                    { 2, 1, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3668) },
                    { 4, 1, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3672) },
                    { 5, 1, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3673) },
                    { 1, 2, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3674) },
                    { 2, 2, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3686) },
                    { 5, 2, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3688) },
                    { 1, 3, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3689) },
                    { 2, 3, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3690) },
                    { 3, 3, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3691) },
                    { 1, 4, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3693) },
                    { 4, 4, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3695) },
                    { 5, 4, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3696) },
                    { 4, 5, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3697) },
                    { 5, 5, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3698) },
                    { 1, 6, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3699) },
                    { 2, 6, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3700) },
                    { 3, 6, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3701) },
                    { 4, 6, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3703) },
                    { 1, 7, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3705) },
                    { 2, 7, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3706) },
                    { 3, 7, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3707) },
                    { 4, 7, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3708) },
                    { 5, 7, null, null, new DateTime(2023, 1, 3, 19, 15, 37, 89, DateTimeKind.Local).AddTicks(3709) }
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
