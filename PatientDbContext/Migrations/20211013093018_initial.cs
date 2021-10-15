using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDbContext.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPatient",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblProblem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genetic = table.Column<bool>(type: "bit", nullable: false),
                    Patientid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProblem", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblProblem_tblPatient_Patientid",
                        column: x => x.Patientid,
                        principalTable: "tblPatient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblMedication",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    freq = table.Column<int>(type: "int", nullable: false),
                    Problemid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedication", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblMedication_tblProblem_Problemid",
                        column: x => x.Problemid,
                        principalTable: "tblProblem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblMedication_Problemid",
                table: "tblMedication",
                column: "Problemid");

            migrationBuilder.CreateIndex(
                name: "IX_tblProblem_Patientid",
                table: "tblProblem",
                column: "Patientid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMedication");

            migrationBuilder.DropTable(
                name: "tblProblem");

            migrationBuilder.DropTable(
                name: "tblPatient");
        }
    }
}
