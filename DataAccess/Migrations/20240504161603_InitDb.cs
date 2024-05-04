using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    idFurniture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.idFurniture);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    idService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.idService);
                });

            migrationBuilder.CreateTable(
                name: "ContactFurniture",
                columns: table => new
                {
                    contactId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactFurniture", x => new { x.contactId, x.idFurniture });
                    table.ForeignKey(
                        name: "FK_ContactFurniture_Contacts_contactId",
                        column: x => x.contactId,
                        principalTable: "Contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactFurniture_Furnitures_idFurniture",
                        column: x => x.idFurniture,
                        principalTable: "Furnitures",
                        principalColumn: "idFurniture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactService",
                columns: table => new
                {
                    contactId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactService", x => new { x.contactId, x.idService });
                    table.ForeignKey(
                        name: "FK_ContactService_Contacts_contactId",
                        column: x => x.contactId,
                        principalTable: "Contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactService_Services_idService",
                        column: x => x.idService,
                        principalTable: "Services",
                        principalColumn: "idService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactFurniture_idFurniture",
                table: "ContactFurniture",
                column: "idFurniture");

            migrationBuilder.CreateIndex(
                name: "IX_ContactService_idService",
                table: "ContactService",
                column: "idService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactFurniture");

            migrationBuilder.DropTable(
                name: "ContactService");

            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
