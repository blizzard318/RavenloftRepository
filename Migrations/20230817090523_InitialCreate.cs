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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraInfo = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalLinks = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Domain_SourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Item_SourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Language_SourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Location_SourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Mistway_SourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    NPC_SourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Contributors = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    DomainId = table.Column<int>(type: "INTEGER", nullable: true),
                    Trait_ItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true),
                    NPCId = table.Column<int>(type: "INTEGER", nullable: true),
                    Trait_SourceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Base_Base_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_Domain_SourceId",
                        column: x => x.Domain_SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_Item_SourceId",
                        column: x => x.Item_SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_Language_SourceId",
                        column: x => x.Language_SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_Location_SourceId",
                        column: x => x.Location_SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_Mistway_SourceId",
                        column: x => x.Mistway_SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_NPCId",
                        column: x => x.NPCId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_NPC_SourceId",
                        column: x => x.NPC_SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_Trait_ItemId",
                        column: x => x.Trait_ItemId,
                        principalTable: "Base",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_Base_Trait_SourceId",
                        column: x => x.Trait_SourceId,
                        principalTable: "Base",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    PageNumbers = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appearances_Base_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appearances_Base_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClusterDomain",
                columns: table => new
                {
                    ClustersId = table.Column<int>(type: "INTEGER", nullable: false),
                    DomainsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterDomain", x => new { x.ClustersId, x.DomainsId });
                    table.ForeignKey(
                        name: "FK_ClusterDomain_Base_ClustersId",
                        column: x => x.ClustersId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClusterDomain_Base_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Base",
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
                        name: "FK_DomainItem_Base_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainItem_Base_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainLanguage",
                columns: table => new
                {
                    DomainsId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguagesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainLanguage", x => new { x.DomainsId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_DomainLanguage_Base_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainLanguage_Base_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainLocation",
                columns: table => new
                {
                    DomainsId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainLocation", x => new { x.DomainsId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_DomainLocation_Base_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainLocation_Base_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainMistway",
                columns: table => new
                {
                    DomainsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MistwaysId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainMistway", x => new { x.DomainsId, x.MistwaysId });
                    table.ForeignKey(
                        name: "FK_DomainMistway_Base_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainMistway_Base_MistwaysId",
                        column: x => x.MistwaysId,
                        principalTable: "Base",
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
                        name: "FK_DomainNPC_Base_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainNPC_Base_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "Base",
                        principalColumn: "Id",
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
                        name: "FK_ItemLocation_Base_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLocation_Base_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageNPC",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    NPCsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageNPC", x => new { x.LanguagesId, x.NPCsId });
                    table.ForeignKey(
                        name: "FK_LanguageNPC_Base_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageNPC_Base_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "Base",
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
                        name: "FK_LocationNPC_Base_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationNPC_Base_NPCsId",
                        column: x => x.NPCsId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_Base_FirstId",
                        column: x => x.FirstId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relationships_Base_SecondId",
                        column: x => x.SecondId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relationships_Base_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_EntityId",
                table: "Appearances",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_SourceId",
                table: "Appearances",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Domain_SourceId",
                table: "Base",
                column: "Domain_SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_DomainId",
                table: "Base",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Item_SourceId",
                table: "Base",
                column: "Item_SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_ItemId",
                table: "Base",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Language_SourceId",
                table: "Base",
                column: "Language_SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Location_SourceId",
                table: "Base",
                column: "Location_SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_LocationId",
                table: "Base",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Mistway_SourceId",
                table: "Base",
                column: "Mistway_SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_NPC_SourceId",
                table: "Base",
                column: "NPC_SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_NPCId",
                table: "Base",
                column: "NPCId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_SourceId",
                table: "Base",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Trait_ItemId",
                table: "Base",
                column: "Trait_ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_Trait_SourceId",
                table: "Base",
                column: "Trait_SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterDomain_DomainsId",
                table: "ClusterDomain",
                column: "DomainsId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainItem_ItemsId",
                table: "DomainItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainLanguage_LanguagesId",
                table: "DomainLanguage",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainLocation_LocationsId",
                table: "DomainLocation",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainMistway_MistwaysId",
                table: "DomainMistway",
                column: "MistwaysId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainNPC_NPCsId",
                table: "DomainNPC",
                column: "NPCsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocation_LocationsId",
                table: "ItemLocation",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageNPC_NPCsId",
                table: "LanguageNPC",
                column: "NPCsId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationNPC_NPCsId",
                table: "LocationNPC",
                column: "NPCsId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_FirstId",
                table: "Relationships",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_SecondId",
                table: "Relationships",
                column: "SecondId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_SourceId",
                table: "Relationships",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "ClusterDomain");

            migrationBuilder.DropTable(
                name: "DomainItem");

            migrationBuilder.DropTable(
                name: "DomainLanguage");

            migrationBuilder.DropTable(
                name: "DomainLocation");

            migrationBuilder.DropTable(
                name: "DomainMistway");

            migrationBuilder.DropTable(
                name: "DomainNPC");

            migrationBuilder.DropTable(
                name: "ItemLocation");

            migrationBuilder.DropTable(
                name: "LanguageNPC");

            migrationBuilder.DropTable(
                name: "LocationNPC");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Base");
        }
    }
}
