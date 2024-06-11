using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure_Layer.Migrations
{
    /// <inheritdoc />
    public partial class step1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MJR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MJR_ID);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UNV_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UNV_ID);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true),
                    Message2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Message3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResumPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yearsofexperience = table.Column<int>(type: "int", nullable: true),
                    yearsofexperience2 = table.Column<int>(type: "int", nullable: true),
                    yearsofexperience3 = table.Column<int>(type: "int", nullable: true),
                    workplace = table.Column<int>(type: "int", nullable: true),
                    UNV_ID = table.Column<int>(type: "int", nullable: true),
                    MJR_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Applicants_Majors_MJR_ID",
                        column: x => x.MJR_ID,
                        principalTable: "Majors",
                        principalColumn: "MJR_ID");
                    table.ForeignKey(
                        name: "FK_Applicants_Universities_UNV_ID",
                        column: x => x.UNV_ID,
                        principalTable: "Universities",
                        principalColumn: "UNV_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_MJR_ID",
                table: "Applicants",
                column: "MJR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UNV_ID",
                table: "Applicants",
                column: "UNV_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
