using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.business.DataAccess.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matters",
                columns: table => new
                {
                    MatterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matters", x => x.MatterId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UsersLname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersFname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Admin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Student_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Teacher_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionBeginAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionEndAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_Permission_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatterTeachers",
                columns: table => new
                {
                    MatterTeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    MatterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterTeachers", x => x.MatterTeacherId);
                    table.ForeignKey(
                        name: "FK_MatterTeachers_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "MatterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatterTeachers_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionCours",
                columns: table => new
                {
                    SessionCoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semestre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Years = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatterId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    HourStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionCours", x => x.SessionCoursId);
                    table.ForeignKey(
                        name: "FK_SessionCours_MatterTeachers_MatterTeacherId",
                        column: x => x.MatterTeacherId,
                        principalTable: "MatterTeachers",
                        principalColumn: "MatterTeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    AbsenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SessionCoursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceId);
                    table.ForeignKey(
                        name: "FK_Absences_SessionCours_SessionCoursId",
                        column: x => x.SessionCoursId,
                        principalTable: "SessionCours",
                        principalColumn: "SessionCoursId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absences_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "justificationAbsences",
                columns: table => new
                {
                    JustificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JustificationEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbsenceId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_justificationAbsences", x => x.JustificationId);
                    table.ForeignKey(
                        name: "FK_justificationAbsences_Absences_AbsenceId",
                        column: x => x.AbsenceId,
                        principalTable: "Absences",
                        principalColumn: "AbsenceId");
                    table.ForeignKey(
                        name: "FK_justificationAbsences_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_SessionCoursId",
                table: "Absences",
                column: "SessionCoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_StudentId",
                table: "Absences",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_justificationAbsences_AbsenceId",
                table: "justificationAbsences",
                column: "AbsenceId",
                unique: true,
                filter: "[AbsenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_justificationAbsences_StudentId",
                table: "justificationAbsences",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterTeachers_MatterId",
                table: "MatterTeachers",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterTeachers_TeacherId",
                table: "MatterTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_StudentId",
                table: "Permission",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionCours_MatterTeacherId",
                table: "SessionCours",
                column: "MatterTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "justificationAbsences");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "SessionCours");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "MatterTeachers");

            migrationBuilder.DropTable(
                name: "Matters");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
