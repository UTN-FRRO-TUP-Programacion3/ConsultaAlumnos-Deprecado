﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaAlumnos.API.Migrations
{
    public partial class InitFullEnglish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quarter = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSubject",
                columns: table => new
                {
                    ProfessorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubject", x => new { x.ProfessorsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_User_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatorStudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionState = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_User_CreatorStudentId",
                        column: x => x.CreatorStudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_User_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSubjectsAttended",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectsAttendedId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubjectsAttended", x => new { x.StudentsId, x.SubjectsAttendedId });
                    table.ForeignKey(
                        name: "FK_StudentsSubjectsAttended_Subjects_SubjectsAttendedId",
                        column: x => x.SubjectsAttendedId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSubjectsAttended_User_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responses_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "Quarter" },
                values: new object[] { 1, "Programación 3", "Tercer" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "Quarter" },
                values: new object[] { 2, "Programación 4", "Tercer" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Discriminator", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 4, "Professor", "nbologna31@gmail.com", "Bologna", "Nicolas", "123456", "nbologna_profesor" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Discriminator", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 5, "Professor", "ppaez@gmail.com", "Paez", "Pablo", "123456", "ppaez" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Discriminator", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "Student", "nbologna31@gmail.com", "Bologna", "Nicolas", "123456", "nbologna_alumno" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Discriminator", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 2, "Student", "Jperez@gmail.com", "Perez", "Juan", "123456", "jperez" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Discriminator", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 3, "Student", "pgarcia@gmail.com", "Garcia", "Pedro", "123456", "pgarcia" });

            migrationBuilder.InsertData(
                table: "ProfessorSubject",
                columns: new[] { "ProfessorsId", "SubjectsId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "ProfessorSubject",
                columns: new[] { "ProfessorsId", "SubjectsId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "ProfessorSubject",
                columns: new[] { "ProfessorsId", "SubjectsId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "StudentsSubjectsAttended",
                columns: new[] { "StudentsId", "SubjectsAttendedId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentsSubjectsAttended",
                columns: new[] { "StudentsId", "SubjectsAttendedId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubject_SubjectsId",
                table: "ProfessorSubject",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatorStudentId",
                table: "Questions",
                column: "CreatorStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ProfessorId",
                table: "Questions",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CreatorId",
                table: "Responses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjectsAttended_SubjectsAttendedId",
                table: "StudentsSubjectsAttended",
                column: "SubjectsAttendedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorSubject");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "StudentsSubjectsAttended");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
