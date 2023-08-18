using System;
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
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NPCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Contributors = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SourceTraits",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceTraits", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Traits",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DomainId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainItem",
                columns: table => new
                {
                    DomainsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainItem", x => new { x.DomainsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_DomainItem_Domains_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainNPC",
                columns: table => new
                {
                    DomainsId = table.Column<int>(type: "INTEGER", nullable: false),
                    NPCsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainNPC", x => new { x.DomainsId, x.NPCsId });
                    table.ForeignKey(
                        name: "FK_DomainNPC_Domains_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainNPC_NPCs_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemNPC",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "INTEGER", nullable: false),
                    NPCsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemNPC", x => new { x.ItemsId, x.NPCsId });
                    table.ForeignKey(
                        name: "FK_ItemNPC_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemNPC_NPCs_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrimaryId = table.Column<int>(type: "INTEGER", nullable: false),
                    OtherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_NPCs_OtherId",
                        column: x => x.OtherId,
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relationships_NPCs_PrimaryId",
                        column: x => x.PrimaryId,
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SourceSourceTrait",
                columns: table => new
                {
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false),
                    TraitsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceSourceTrait", x => new { x.SourcesName, x.TraitsName });
                    table.ForeignKey(
                        name: "FK_SourceSourceTrait_SourceTraits_TraitsName",
                        column: x => x.TraitsName,
                        principalTable: "SourceTraits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SourceSourceTrait_Sources_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Sources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainTrait",
                columns: table => new
                {
                    DomainsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TraitsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainTrait", x => new { x.DomainsId, x.TraitsName });
                    table.ForeignKey(
                        name: "FK_DomainTrait_Domains_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainTrait_Traits_TraitsName",
                        column: x => x.TraitsName,
                        principalTable: "Traits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTrait",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TraitsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTrait", x => new { x.ItemsId, x.TraitsName });
                    table.ForeignKey(
                        name: "FK_ItemTrait_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTrait_Traits_TraitsName",
                        column: x => x.TraitsName,
                        principalTable: "Traits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NPCTrait",
                columns: table => new
                {
                    NPCsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TraitsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCTrait", x => new { x.NPCsId, x.TraitsName });
                    table.ForeignKey(
                        name: "FK_NPCTrait_NPCs_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPCTrait_Traits_TraitsName",
                        column: x => x.TraitsName,
                        principalTable: "Traits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceName = table.Column<string>(type: "TEXT", nullable: false),
                    PageNumbers = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Domain = table.Column<int>(type: "INTEGER", nullable: true),
                    Item = table.Column<int>(type: "INTEGER", nullable: true),
                    Location = table.Column<int>(type: "INTEGER", nullable: true),
                    NPC = table.Column<int>(type: "INTEGER", nullable: true),
                    Trait = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appearances_Domains_Domain",
                        column: x => x.Domain,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Items_Item",
                        column: x => x.Item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Locations_Location",
                        column: x => x.Location,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_NPCs_NPC",
                        column: x => x.NPC,
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Sources_SourceName",
                        column: x => x.SourceName,
                        principalTable: "Sources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Traits_Trait",
                        column: x => x.Trait,
                        principalTable: "Traits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemLocation",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLocation", x => new { x.ItemsId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_ItemLocation_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLocation_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationNPC",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "INTEGER", nullable: false),
                    NPCsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationNPC", x => new { x.LocationsId, x.NPCsId });
                    table.ForeignKey(
                        name: "FK_LocationNPC_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationNPC_NPCs_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "NPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationTrait",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TraitsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTrait", x => new { x.LocationsId, x.TraitsName });
                    table.ForeignKey(
                        name: "FK_LocationTrait_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationTrait_Traits_TraitsName",
                        column: x => x.TraitsName,
                        principalTable: "Traits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_Domain",
                table: "Appearances",
                column: "Domain");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_Item",
                table: "Appearances",
                column: "Item");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_Location",
                table: "Appearances",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_NPC",
                table: "Appearances",
                column: "NPC");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_SourceName",
                table: "Appearances",
                column: "SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_Trait",
                table: "Appearances",
                column: "Trait");

            migrationBuilder.CreateIndex(
                name: "IX_DomainItem_ItemsId",
                table: "DomainItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainNPC_NPCsId",
                table: "DomainNPC",
                column: "NPCsId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainTrait_TraitsName",
                table: "DomainTrait",
                column: "TraitsName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocation_LocationsId",
                table: "ItemLocation",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemNPC_NPCsId",
                table: "ItemNPC",
                column: "NPCsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTrait_TraitsName",
                table: "ItemTrait",
                column: "TraitsName");

            migrationBuilder.CreateIndex(
                name: "IX_LocationNPC_NPCsId",
                table: "LocationNPC",
                column: "NPCsId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DomainId",
                table: "Locations",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTrait_TraitsName",
                table: "LocationTrait",
                column: "TraitsName");

            migrationBuilder.CreateIndex(
                name: "IX_NPCTrait_TraitsName",
                table: "NPCTrait",
                column: "TraitsName");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_OtherId",
                table: "Relationships",
                column: "OtherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_PrimaryId",
                table: "Relationships",
                column: "PrimaryId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceSourceTrait_TraitsName",
                table: "SourceSourceTrait",
                column: "TraitsName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "DomainItem");

            migrationBuilder.DropTable(
                name: "DomainNPC");

            migrationBuilder.DropTable(
                name: "DomainTrait");

            migrationBuilder.DropTable(
                name: "ItemLocation");

            migrationBuilder.DropTable(
                name: "ItemNPC");

            migrationBuilder.DropTable(
                name: "ItemTrait");

            migrationBuilder.DropTable(
                name: "LocationNPC");

            migrationBuilder.DropTable(
                name: "LocationTrait");

            migrationBuilder.DropTable(
                name: "NPCTrait");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "SourceSourceTrait");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Traits");

            migrationBuilder.DropTable(
                name: "NPCs");

            migrationBuilder.DropTable(
                name: "SourceTraits");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
