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
                    Description = table.Column<string>(type: "TEXT", nullable: false)
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
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clusters", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Clusters_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Items_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Mistways",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    ClusterName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mistways", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Mistways_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Mistways_Clusters_ClusterName",
                        column: x => x.ClusterName,
                        principalTable: "Clusters",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "NPCs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Aliases = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCs", x => x.Name);
                    table.ForeignKey(
                        name: "FK_NPCs_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_NPCs_Items_ItemName",
                        column: x => x.ItemName,
                        principalTable: "Items",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "ClusterSource",
                columns: table => new
                {
                    ClustersName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterSource", x => new { x.ClustersName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_ClusterSource_Clusters_ClustersName",
                        column: x => x.ClustersName,
                        principalTable: "Clusters",
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
                        name: "FK_CreatureTraitNPC_NPCs_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "NPCs",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTraits",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    EditionName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTraits", x => x.Name);
                    table.ForeignKey(
                        name: "FK_CreatureTraits_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Names = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    ClosedBorders = table.Column<string>(type: "TEXT", nullable: false),
                    ClusterName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatureTraitName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Domains_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Domains_Clusters_ClusterName",
                        column: x => x.ClusterName,
                        principalTable: "Clusters",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Domains_CreatureTraits_CreatureTraitName",
                        column: x => x.CreatureTraitName,
                        principalTable: "CreatureTraits",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Domains_Items_ItemName",
                        column: x => x.ItemName,
                        principalTable: "Items",
                        principalColumn: "Name");
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
                        name: "FK_DomainMistway_Domains_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Domains",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainMistway_Mistways_MistwaysName",
                        column: x => x.MistwaysName,
                        principalTable: "Mistways",
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
                        name: "FK_DomainNPC_Domains_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Domains",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainNPC_NPCs_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "NPCs",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    DomainName = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Locations_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Locations_Domains_DomainName",
                        column: x => x.DomainName,
                        principalTable: "Domains",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_LocationName",
                        column: x => x.LocationName,
                        principalTable: "Locations",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Editions_Locations_LocationName",
                        column: x => x.LocationName,
                        principalTable: "Locations",
                        principalColumn: "Name");
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
                        name: "FK_ItemLocation_Items_ItemsName",
                        column: x => x.ItemsName,
                        principalTable: "Items",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLocation_Locations_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Locations",
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
                        name: "FK_LocationNPC_Locations_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Locations",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationNPC_NPCs_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "NPCs",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainEdition",
                columns: table => new
                {
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false),
                    EditionsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEdition", x => new { x.DomainsName, x.EditionsName });
                    table.ForeignKey(
                        name: "FK_DomainEdition_Domains_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Domains",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainEdition_Editions_EditionsName",
                        column: x => x.EditionsName,
                        principalTable: "Editions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionItem",
                columns: table => new
                {
                    EditionsName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionItem", x => new { x.EditionsName, x.ItemsName });
                    table.ForeignKey(
                        name: "FK_EditionItem_Editions_EditionsName",
                        column: x => x.EditionsName,
                        principalTable: "Editions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditionItem_Items_ItemsName",
                        column: x => x.ItemsName,
                        principalTable: "Items",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionNPC",
                columns: table => new
                {
                    EditionsName = table.Column<string>(type: "TEXT", nullable: false),
                    NPCsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionNPC", x => new { x.EditionsName, x.NPCsName });
                    table.ForeignKey(
                        name: "FK_EditionNPC_Editions_EditionsName",
                        column: x => x.EditionsName,
                        principalTable: "Editions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditionNPC_NPCs_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "NPCs",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    EditionName = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<string>(type: "TEXT", nullable: false),
                    Contributors = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Sources_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Sources_Editions_EditionName",
                        column: x => x.EditionName,
                        principalTable: "Editions",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "CreatureTraitSource",
                columns: table => new
                {
                    CreatureTraitsName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTraitSource", x => new { x.CreatureTraitsName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_CreatureTraitSource_CreatureTraits_CreatureTraitsName",
                        column: x => x.CreatureTraitsName,
                        principalTable: "CreatureTraits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureTraitSource_Sources_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Sources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainSource",
                columns: table => new
                {
                    DomainsName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainSource", x => new { x.DomainsName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_DomainSource_Domains_DomainsName",
                        column: x => x.DomainsName,
                        principalTable: "Domains",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainSource_Sources_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Sources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSource",
                columns: table => new
                {
                    ItemsName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSource", x => new { x.ItemsName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_ItemSource_Items_ItemsName",
                        column: x => x.ItemsName,
                        principalTable: "Items",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSource_Sources_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Sources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTraits",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanonName = table.Column<string>(type: "TEXT", nullable: true),
                    SourceName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTraits", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ItemTraits_Canons_CanonName",
                        column: x => x.CanonName,
                        principalTable: "Canons",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_ItemTraits_Sources_SourceName",
                        column: x => x.SourceName,
                        principalTable: "Sources",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "LocationSource",
                columns: table => new
                {
                    LocationsName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSource", x => new { x.LocationsName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_LocationSource_Locations_LocationsName",
                        column: x => x.LocationsName,
                        principalTable: "Locations",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationSource_Sources_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Sources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MistwaySource",
                columns: table => new
                {
                    MistwaysName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MistwaySource", x => new { x.MistwaysName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_MistwaySource_Mistways_MistwaysName",
                        column: x => x.MistwaysName,
                        principalTable: "Mistways",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MistwaySource_Sources_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Sources",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NPCSource",
                columns: table => new
                {
                    NPCsName = table.Column<string>(type: "TEXT", nullable: false),
                    SourcesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCSource", x => new { x.NPCsName, x.SourcesName });
                    table.ForeignKey(
                        name: "FK_NPCSource_NPCs_NPCsName",
                        column: x => x.NPCsName,
                        principalTable: "NPCs",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPCSource_Sources_SourcesName",
                        column: x => x.SourcesName,
                        principalTable: "Sources",
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
                        name: "FK_ItemItemTrait_ItemTraits_ItemTraitsName",
                        column: x => x.ItemTraitsName,
                        principalTable: "ItemTraits",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemItemTrait_Items_ItemsName",
                        column: x => x.ItemsName,
                        principalTable: "Items",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clusters_CanonName",
                table: "Clusters",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterSource_SourcesName",
                table: "ClusterSource",
                column: "SourcesName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraitLocation_LocationsName",
                table: "CreatureTraitLocation",
                column: "LocationsName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraitNPC_NPCsName",
                table: "CreatureTraitNPC",
                column: "NPCsName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraits_CanonName",
                table: "CreatureTraits",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraits_EditionName",
                table: "CreatureTraits",
                column: "EditionName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTraitSource_SourcesName",
                table: "CreatureTraitSource",
                column: "SourcesName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEdition_EditionsName",
                table: "DomainEdition",
                column: "EditionsName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainMistway_MistwaysName",
                table: "DomainMistway",
                column: "MistwaysName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainNPC_NPCsName",
                table: "DomainNPC",
                column: "NPCsName");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_CanonName",
                table: "Domains",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_ClusterName",
                table: "Domains",
                column: "ClusterName");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_CreatureTraitName",
                table: "Domains",
                column: "CreatureTraitName");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_ItemName",
                table: "Domains",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_DomainSource_SourcesName",
                table: "DomainSource",
                column: "SourcesName");

            migrationBuilder.CreateIndex(
                name: "IX_EditionItem_ItemsName",
                table: "EditionItem",
                column: "ItemsName");

            migrationBuilder.CreateIndex(
                name: "IX_EditionNPC_NPCsName",
                table: "EditionNPC",
                column: "NPCsName");

            migrationBuilder.CreateIndex(
                name: "IX_Editions_LocationName",
                table: "Editions",
                column: "LocationName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemItemTrait_ItemsName",
                table: "ItemItemTrait",
                column: "ItemsName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocation_LocationsName",
                table: "ItemLocation",
                column: "LocationsName");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CanonName",
                table: "Items",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSource_SourcesName",
                table: "ItemSource",
                column: "SourcesName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTraits_CanonName",
                table: "ItemTraits",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTraits_SourceName",
                table: "ItemTraits",
                column: "SourceName");

            migrationBuilder.CreateIndex(
                name: "IX_LocationNPC_NPCsName",
                table: "LocationNPC",
                column: "NPCsName");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CanonName",
                table: "Locations",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DomainName",
                table: "Locations",
                column: "DomainName");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationName",
                table: "Locations",
                column: "LocationName");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSource_SourcesName",
                table: "LocationSource",
                column: "SourcesName");

            migrationBuilder.CreateIndex(
                name: "IX_Mistways_CanonName",
                table: "Mistways",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_Mistways_ClusterName",
                table: "Mistways",
                column: "ClusterName");

            migrationBuilder.CreateIndex(
                name: "IX_MistwaySource_SourcesName",
                table: "MistwaySource",
                column: "SourcesName");

            migrationBuilder.CreateIndex(
                name: "IX_NPCs_CanonName",
                table: "NPCs",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_NPCs_ItemName",
                table: "NPCs",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_NPCSource_SourcesName",
                table: "NPCSource",
                column: "SourcesName");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_CanonName",
                table: "Sources",
                column: "CanonName");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_EditionName",
                table: "Sources",
                column: "EditionName");

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterSource_Sources_SourcesName",
                table: "ClusterSource",
                column: "SourcesName",
                principalTable: "Sources",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureTraitLocation_CreatureTraits_CreatureTraitsName",
                table: "CreatureTraitLocation",
                column: "CreatureTraitsName",
                principalTable: "CreatureTraits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureTraitLocation_Locations_LocationsName",
                table: "CreatureTraitLocation",
                column: "LocationsName",
                principalTable: "Locations",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureTraitNPC_CreatureTraits_CreatureTraitsName",
                table: "CreatureTraitNPC",
                column: "CreatureTraitsName",
                principalTable: "CreatureTraits",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureTraits_Editions_EditionName",
                table: "CreatureTraits",
                column: "EditionName",
                principalTable: "Editions",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clusters_Canons_CanonName",
                table: "Clusters");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureTraits_Canons_CanonName",
                table: "CreatureTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_Canons_CanonName",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Canons_CanonName",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Canons_CanonName",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_Clusters_ClusterName",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_CreatureTraits_CreatureTraitName",
                table: "Domains");

            migrationBuilder.DropTable(
                name: "ClusterSource");

            migrationBuilder.DropTable(
                name: "CreatureTraitLocation");

            migrationBuilder.DropTable(
                name: "CreatureTraitNPC");

            migrationBuilder.DropTable(
                name: "CreatureTraitSource");

            migrationBuilder.DropTable(
                name: "DomainEdition");

            migrationBuilder.DropTable(
                name: "DomainMistway");

            migrationBuilder.DropTable(
                name: "DomainNPC");

            migrationBuilder.DropTable(
                name: "DomainSource");

            migrationBuilder.DropTable(
                name: "EditionItem");

            migrationBuilder.DropTable(
                name: "EditionNPC");

            migrationBuilder.DropTable(
                name: "ItemItemTrait");

            migrationBuilder.DropTable(
                name: "ItemLocation");

            migrationBuilder.DropTable(
                name: "ItemSource");

            migrationBuilder.DropTable(
                name: "LocationNPC");

            migrationBuilder.DropTable(
                name: "LocationSource");

            migrationBuilder.DropTable(
                name: "MistwaySource");

            migrationBuilder.DropTable(
                name: "NPCSource");

            migrationBuilder.DropTable(
                name: "ItemTraits");

            migrationBuilder.DropTable(
                name: "Mistways");

            migrationBuilder.DropTable(
                name: "NPCs");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Canons");

            migrationBuilder.DropTable(
                name: "Clusters");

            migrationBuilder.DropTable(
                name: "CreatureTraits");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
