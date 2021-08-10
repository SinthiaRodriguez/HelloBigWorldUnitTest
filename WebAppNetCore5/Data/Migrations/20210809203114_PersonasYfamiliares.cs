using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppNetCore5.Data.Migrations
{
    public partial class PersonasYfamiliares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelacionsPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    PersonaFamiliarId = table.Column<int>(type: "int", nullable: false),
                    Parentezco = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionsPersonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelacionsPersonas_Personas_PersonaFamiliarId",
                        column: x => x.PersonaFamiliarId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelacionsPersonas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelacionsPersonas_PersonaFamiliarId",
                table: "RelacionsPersonas",
                column: "PersonaFamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacionsPersonas_PersonaId_PersonaFamiliarId_Parentezco",
                table: "RelacionsPersonas",
                columns: new[] { "PersonaId", "PersonaFamiliarId", "Parentezco" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacionsPersonas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
