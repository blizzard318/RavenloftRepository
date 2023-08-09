using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ravenloft.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canons",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canons", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Clusters",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clusters", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTraits",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTraits", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Names = table.Column<string>(type: "TEXT", nullable: false),
                    ClosedBorders = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ItemTraits",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTraits", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Mistways",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mistways", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "NPCs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Aliases = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCs", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<string>(type: "TEXT", nullable: false),
                    Contributors = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canons");

            migrationBuilder.DropTable(
                name: "Clusters");

            migrationBuilder.DropTable(
                name: "CreatureTraits");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemTraits");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Mistways");

            migrationBuilder.DropTable(
                name: "NPCs");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
