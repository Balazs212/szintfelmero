using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szintfelmero.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_821 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orszagok",
                columns: table => new
                {
                    orszagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    orszagNeve = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orszagok", x => x.orszagId);
                });

            migrationBuilder.CreateTable(
                name: "Szakmak",
                columns: table => new
                {
                    szakmaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    szakmaNeve = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szakmak", x => x.szakmaId);
                });

            migrationBuilder.CreateTable(
                name: "Versenyzok",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nev = table.Column<string>(type: "TEXT", nullable: false),
                    szakmaId = table.Column<int>(type: "INTEGER", nullable: false),
                    orszagId = table.Column<int>(type: "INTEGER", nullable: false),
                    pontszam = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versenyzok", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orszagok");

            migrationBuilder.DropTable(
                name: "Szakmak");

            migrationBuilder.DropTable(
                name: "Versenyzok");
        }
    }
}
