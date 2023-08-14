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
                name: "Base",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatureTrait_SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    EventName = table.Column<string>(type: "TEXT", nullable: true),
                    Domain_SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    CreatureTraitName = table.Column<string>(type: "TEXT", nullable: true),
                    Item_EventName = table.Column<string>(type: "TEXT", nullable: true),
                    Item_SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    Location_EventName = table.Column<string>(type: "TEXT", nullable: true),
                    Location_SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    Mistway_SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    NPC_EventName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    NPC_SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Contributors = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Base_Base_CreatureTraitName",
                        column: x => x.CreatureTraitName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_CreatureTrait_SourceName",
                        column: x => x.CreatureTrait_SourceName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_Domain_SourceName",
                        column: x => x.Domain_SourceName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_EventName",
                        column: x => x.EventName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_ItemName",
                        column: x => x.ItemName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_Item_EventName",
                        column: x => x.Item_EventName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_Item_SourceName",
                        column: x => x.Item_SourceName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_Location_EventName",
                        column: x => x.Location_EventName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_Location_SourceName",
                        column: x => x.Location_SourceName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_Mistway_SourceName",
                        column: x => x.Mistway_SourceName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_NPC_EventName",
                        column: x => x.NPC_EventName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_NPC_SourceName",
                        column: x => x.NPC_SourceName,
                        principalTable: "Base",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Base_Base_SourceName",
                        column: x => x.SourceName,
                        principalTable: "Base",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceName = table.Column<string>(type: "TEXT", nullable: false),
                    EntityName = table.Column<string>(type: "TEXT", nullable: false),
                    PageNumbers = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appearances_Base_EntityName",
                        column: x => x.EntityName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Base_SourceName",
                        column: x => x.SourceName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClusterDomain",
                columns: table => new
                {
                    ClustersName = table.Column<string>(type: "TEXT", nullable: false),
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterDomain", x => new { x.ClustersName, x.DomainsName });
                    table.ForeignKey(
                        name: "FK_ClusterDomain_Base_ClustersName",
                        column: x => x.ClustersName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClusterDomain_Base_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTraitDomain",
                columns: table => new
                {
                    CreatureTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTraitDomain", x => new { x.CreatureTraitsName, x.DomainsName });
                    table.ForeignKey(
                        name: "FK_CreatureTraitDomain_Base_CreatureTraitsName",
                        column: x => x.CreatureTraitsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureTraitDomain_Base_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTraitLocation",
                columns: table => new
                {
                    CreatureTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTraitLocation", x => new { x.CreatureTraitsName, x.LocationsName });
                    table.ForeignKey(
                        name: "FK_CreatureTraitLocation_Base_CreatureTraitsName",
                        column: x => x.CreatureTraitsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureTraitLocation_Base_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTraitNPC",
                columns: table => new
                {
                    CreatureTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    NPCsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTraitNPC", x => new { x.CreatureTraitsName, x.NPCsName });
                    table.ForeignKey(
                        name: "FK_CreatureTraitNPC_Base_CreatureTraitsName",
                        column: x => x.CreatureTraitsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureTraitNPC_Base_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainDomainTrait",
                columns: table => new
                {
                    DomainTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainDomainTrait", x => new { x.DomainTraitsName, x.DomainsName });
                    table.ForeignKey(
                        name: "FK_DomainDomainTrait_Base_DomainTraitsName",
                        column: x => x.DomainTraitsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainDomainTrait_Base_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainItem",
                columns: table => new
                {
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainItem", x => new { x.DomainsName, x.ItemsName });
                    table.ForeignKey(
                        name: "FK_DomainItem_Base_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainItem_Base_ItemsName",
                        column: x => x.ItemsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainLocation",
                columns: table => new
                {
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainLocation", x => new { x.DomainsName, x.LocationsName });
                    table.ForeignKey(
                        name: "FK_DomainLocation_Base_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainLocation_Base_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainMistway",
                columns: table => new
                {
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false),
                    MistwaysName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainMistway", x => new { x.DomainsName, x.MistwaysName });
                    table.ForeignKey(
                        name: "FK_DomainMistway_Base_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainMistway_Base_MistwaysName",
                        column: x => x.MistwaysName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainNPC",
                columns: table => new
                {
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false),
                    NPCsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainNPC", x => new { x.DomainsName, x.NPCsName });
                    table.ForeignKey(
                        name: "FK_DomainNPC_Base_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainNPC_Base_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemItemTrait",
                columns: table => new
                {
                    ItemTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemItemTrait", x => new { x.ItemTraitsName, x.ItemsName });
                    table.ForeignKey(
                        name: "FK_ItemItemTrait_Base_ItemTraitsName",
                        column: x => x.ItemTraitsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemItemTrait_Base_ItemsName",
                        column: x => x.ItemsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemLocation",
                columns: table => new
                {
                    ItemsName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLocation", x => new { x.ItemsName, x.LocationsName });
                    table.ForeignKey(
                        name: "FK_ItemLocation_Base_ItemsName",
                        column: x => x.ItemsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLocation_Base_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationLocationTrait",
                columns: table => new
                {
                    LocationTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationLocationTrait", x => new { x.LocationTraitsName, x.LocationsName });
                    table.ForeignKey(
                        name: "FK_LocationLocationTrait_Base_LocationTraitsName",
                        column: x => x.LocationTraitsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationLocationTrait_Base_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationNPC",
                columns: table => new
                {
                    LocationsName = table.Column<string>(type: "TEXT", nullable: false),
                    NPCsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationNPC", x => new { x.LocationsName, x.NPCsName });
                    table.ForeignKey(
                        name: "FK_LocationNPC_Base_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationNPC_Base_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SourceSourceTrait",
                columns: table => new
                {
                    SourceTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceSourceTrait", x => new { x.SourceTraitsName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_SourceSourceTrait_Base_SourceTraitsName",
                        column: x => x.SourceTraitsName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SourceSourceTrait_Base_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Base",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_EntityName",
                table: "Appearances",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_SourceName",
                table: "Appearances",
                column: "SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_CreatureTrait_SourceName",
                table: "Base",
                column: "CreatureTrait_SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_CreatureTraitName",
                table: "Base",
                column: "CreatureTraitName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Domain_SourceName",
                table: "Base",
                column: "Domain_SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_EventName",
                table: "Base",
                column: "EventName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Item_EventName",
                table: "Base",
                column: "Item_EventName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Item_SourceName",
                table: "Base",
                column: "Item_SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_ItemName",
                table: "Base",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Location_EventName",
                table: "Base",
                column: "Location_EventName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Location_SourceName",
                table: "Base",
                column: "Location_SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Mistway_SourceName",
                table: "Base",
                column: "Mistway_SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_NPC_EventName",
                table: "Base",
                column: "NPC_EventName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_NPC_SourceName",
                table: "Base",
                column: "NPC_SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_Base_SourceName",
                table: "Base",
                column: "SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterDomain_DomainsName",
                table: "ClusterDomain",
                column: "DomainsName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraitDomain_DomainsName",
                table: "CreatureTraitDomain",
                column: "DomainsName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraitLocation_LocationsName",
                table: "CreatureTraitLocation",
                column: "LocationsName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraitNPC_NPCsName",
                table: "CreatureTraitNPC",
                column: "NPCsName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainDomainTrait_DomainsName",
                table: "DomainDomainTrait",
                column: "DomainsName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainItem_ItemsName",
                table: "DomainItem",
                column: "ItemsName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainLocation_LocationsName",
                table: "DomainLocation",
                column: "LocationsName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainMistway_MistwaysName",
                table: "DomainMistway",
                column: "MistwaysName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainNPC_NPCsName",
                table: "DomainNPC",
                column: "NPCsName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemItemTrait_ItemsName",
                table: "ItemItemTrait",
                column: "ItemsName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocation_LocationsName",
                table: "ItemLocation",
                column: "LocationsName");

            migrationBuilder.CreateIndex(
                name: "IX_LocationLocationTrait_LocationsName",
                table: "LocationLocationTrait",
                column: "LocationsName");

            migrationBuilder.CreateIndex(
                name: "IX_LocationNPC_NPCsName",
                table: "LocationNPC",
                column: "NPCsName");

            migrationBuilder.CreateIndex(
                name: "IX_SourceSourceTrait_SourcesName",
                table: "SourceSourceTrait",
                column: "SourcesName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "ClusterDomain");

            migrationBuilder.DropTable(
                name: "CreatureTraitDomain");

            migrationBuilder.DropTable(
                name: "CreatureTraitLocation");

            migrationBuilder.DropTable(
                name: "CreatureTraitNPC");

            migrationBuilder.DropTable(
                name: "DomainDomainTrait");

            migrationBuilder.DropTable(
                name: "DomainItem");

            migrationBuilder.DropTable(
                name: "DomainLocation");

            migrationBuilder.DropTable(
                name: "DomainMistway");

            migrationBuilder.DropTable(
                name: "DomainNPC");

            migrationBuilder.DropTable(
                name: "ItemItemTrait");

            migrationBuilder.DropTable(
                name: "ItemLocation");

            migrationBuilder.DropTable(
                name: "LocationLocationTrait");

            migrationBuilder.DropTable(
                name: "LocationNPC");

            migrationBuilder.DropTable(
                name: "SourceSourceTrait");

            migrationBuilder.DropTable(
                name: "Base");
        }
    }
}
