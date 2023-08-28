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
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "NPCs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OriginalName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "SourceTraits",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceTraits", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Traits",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "DomainItem",
                columns: table => new
                {
                    DomainsKey = table.Column<string>(type: "TEXT", nullable: false),
                    ItemsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainItem", x => new { x.DomainsKey, x.ItemsKey });
                    table.ForeignKey(
                        name: "FK_DomainItem_Domains_DomainsKey",
                        column: x => x.DomainsKey,
                        principalTable: "Domains",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainItem_Items_ItemsKey",
                        column: x => x.ItemsKey,
                        principalTable: "Items",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainLocation",
                columns: table => new
                {
                    DomainsKey = table.Column<string>(type: "TEXT", nullable: false),
                    LocationsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainLocation", x => new { x.DomainsKey, x.LocationsKey });
                    table.ForeignKey(
                        name: "FK_DomainLocation_Domains_DomainsKey",
                        column: x => x.DomainsKey,
                        principalTable: "Domains",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainLocation_Locations_LocationsKey",
                        column: x => x.LocationsKey,
                        principalTable: "Locations",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainNPC",
                columns: table => new
                {
                    DomainsKey = table.Column<string>(type: "TEXT", nullable: false),
                    NPCsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainNPC", x => new { x.DomainsKey, x.NPCsKey });
                    table.ForeignKey(
                        name: "FK_DomainNPC_Domains_DomainsKey",
                        column: x => x.DomainsKey,
                        principalTable: "Domains",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainNPC_NPCs_NPCsKey",
                        column: x => x.NPCsKey,
                        principalTable: "NPCs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationNPC",
                columns: table => new
                {
                    LocationsKey = table.Column<string>(type: "TEXT", nullable: false),
                    NPCsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationNPC", x => new { x.LocationsKey, x.NPCsKey });
                    table.ForeignKey(
                        name: "FK_LocationNPC_Locations_LocationsKey",
                        column: x => x.LocationsKey,
                        principalTable: "Locations",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationNPC_NPCs_NPCsKey",
                        column: x => x.NPCsKey,
                        principalTable: "NPCs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrimaryName = table.Column<string>(type: "TEXT", nullable: false),
                    OtherName = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_NPCs_OtherName",
                        column: x => x.OtherName,
                        principalTable: "NPCs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relationships_NPCs_PrimaryName",
                        column: x => x.PrimaryName,
                        principalTable: "NPCs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", nullable: false),
                    PageNumbers = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Domain = table.Column<string>(type: "TEXT", nullable: true),
                    Item = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    NPC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appearances_Domains_Domain",
                        column: x => x.Domain,
                        principalTable: "Domains",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Items_Item",
                        column: x => x.Item,
                        principalTable: "Items",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Locations_Location",
                        column: x => x.Location,
                        principalTable: "Locations",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_NPCs_NPC",
                        column: x => x.NPC,
                        principalTable: "NPCs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Sources_Source",
                        column: x => x.Source,
                        principalTable: "Sources",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SourceTrait",
                columns: table => new
                {
                    SourcesKey = table.Column<string>(type: "TEXT", nullable: false),
                    TraitsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceTrait", x => new { x.SourcesKey, x.TraitsKey });
                    table.ForeignKey(
                        name: "FK_SourceTrait_SourceTraits_TraitsKey",
                        column: x => x.TraitsKey,
                        principalTable: "SourceTraits",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SourceTrait_Sources_SourcesKey",
                        column: x => x.SourcesKey,
                        principalTable: "Sources",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainTrait",
                columns: table => new
                {
                    DomainsKey = table.Column<string>(type: "TEXT", nullable: false),
                    TraitsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainTrait", x => new { x.DomainsKey, x.TraitsKey });
                    table.ForeignKey(
                        name: "FK_DomainTrait_Domains_DomainsKey",
                        column: x => x.DomainsKey,
                        principalTable: "Domains",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainTrait_Traits_TraitsKey",
                        column: x => x.TraitsKey,
                        principalTable: "Traits",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTrait",
                columns: table => new
                {
                    ItemsKey = table.Column<string>(type: "TEXT", nullable: false),
                    TraitsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTrait", x => new { x.ItemsKey, x.TraitsKey });
                    table.ForeignKey(
                        name: "FK_ItemTrait_Items_ItemsKey",
                        column: x => x.ItemsKey,
                        principalTable: "Items",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTrait_Traits_TraitsKey",
                        column: x => x.TraitsKey,
                        principalTable: "Traits",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationTrait",
                columns: table => new
                {
                    LocationsKey = table.Column<string>(type: "TEXT", nullable: false),
                    TraitsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTrait", x => new { x.LocationsKey, x.TraitsKey });
                    table.ForeignKey(
                        name: "FK_LocationTrait_Locations_LocationsKey",
                        column: x => x.LocationsKey,
                        principalTable: "Locations",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationTrait_Traits_TraitsKey",
                        column: x => x.TraitsKey,
                        principalTable: "Traits",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NPCTrait",
                columns: table => new
                {
                    NPCsKey = table.Column<string>(type: "TEXT", nullable: false),
                    TraitsKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCTrait", x => new { x.NPCsKey, x.TraitsKey });
                    table.ForeignKey(
                        name: "FK_NPCTrait_NPCs_NPCsKey",
                        column: x => x.NPCsKey,
                        principalTable: "NPCs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPCTrait_Traits_TraitsKey",
                        column: x => x.TraitsKey,
                        principalTable: "Traits",
                        principalColumn: "Key",
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
                name: "IX_Appearances_Source",
                table: "Appearances",
                column: "Source");

            migrationBuilder.CreateIndex(
                name: "IX_DomainItem_ItemsKey",
                table: "DomainItem",
                column: "ItemsKey");

            migrationBuilder.CreateIndex(
                name: "IX_DomainLocation_LocationsKey",
                table: "DomainLocation",
                column: "LocationsKey");

            migrationBuilder.CreateIndex(
                name: "IX_DomainNPC_NPCsKey",
                table: "DomainNPC",
                column: "NPCsKey");

            migrationBuilder.CreateIndex(
                name: "IX_DomainTrait_TraitsKey",
                table: "DomainTrait",
                column: "TraitsKey");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTrait_TraitsKey",
                table: "ItemTrait",
                column: "TraitsKey");

            migrationBuilder.CreateIndex(
                name: "IX_LocationNPC_NPCsKey",
                table: "LocationNPC",
                column: "NPCsKey");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTrait_TraitsKey",
                table: "LocationTrait",
                column: "TraitsKey");

            migrationBuilder.CreateIndex(
                name: "IX_NPCTrait_TraitsKey",
                table: "NPCTrait",
                column: "TraitsKey");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_OtherName",
                table: "Relationships",
                column: "OtherName");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_PrimaryName",
                table: "Relationships",
                column: "PrimaryName");

            migrationBuilder.CreateIndex(
                name: "IX_SourceTrait_TraitsKey",
                table: "SourceTrait",
                column: "TraitsKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "DomainItem");

            migrationBuilder.DropTable(
                name: "DomainLocation");

            migrationBuilder.DropTable(
                name: "DomainNPC");

            migrationBuilder.DropTable(
                name: "DomainTrait");

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
                name: "SourceTrait");

            migrationBuilder.DropTable(
                name: "Domains");

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
        }
    }
}
