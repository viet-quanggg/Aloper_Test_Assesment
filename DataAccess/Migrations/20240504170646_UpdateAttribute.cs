using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactFurniture_Contacts_contactId",
                table: "ContactFurniture");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactFurniture_Furnitures_idFurniture",
                table: "ContactFurniture");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactService_Contacts_contactId",
                table: "ContactService");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactService_Services_idService",
                table: "ContactService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactService",
                table: "ContactService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactFurniture",
                table: "ContactFurniture");

            migrationBuilder.RenameTable(
                name: "ContactService",
                newName: "ContactServices");

            migrationBuilder.RenameTable(
                name: "ContactFurniture",
                newName: "ContactFurnitures");

            migrationBuilder.RenameIndex(
                name: "IX_ContactService_idService",
                table: "ContactServices",
                newName: "IX_ContactServices_idService");

            migrationBuilder.RenameIndex(
                name: "IX_ContactFurniture_idFurniture",
                table: "ContactFurnitures",
                newName: "IX_ContactFurnitures_idFurniture");

            migrationBuilder.AddColumn<string>(
                name: "dvt",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "oldNumber",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "priceService",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Furnitures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Furnitures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthOfDay",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "contractEndDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateRange",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "depositAmount",
                table: "Contacts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "depositDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "idRoom",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "identification",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "issuedBy",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "numberOfPeople",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numberOfVehicle",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "permanentAddress",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "rentalStartDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "rentalTerm",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "retailPrice",
                table: "Contacts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "signature",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactServices",
                table: "ContactServices",
                columns: new[] { "contactId", "idService" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactFurnitures",
                table: "ContactFurnitures",
                columns: new[] { "contactId", "idFurniture" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactFurnitures_Contacts_contactId",
                table: "ContactFurnitures",
                column: "contactId",
                principalTable: "Contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactFurnitures_Furnitures_idFurniture",
                table: "ContactFurnitures",
                column: "idFurniture",
                principalTable: "Furnitures",
                principalColumn: "idFurniture",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactServices_Contacts_contactId",
                table: "ContactServices",
                column: "contactId",
                principalTable: "Contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactServices_Services_idService",
                table: "ContactServices",
                column: "idService",
                principalTable: "Services",
                principalColumn: "idService",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactFurnitures_Contacts_contactId",
                table: "ContactFurnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactFurnitures_Furnitures_idFurniture",
                table: "ContactFurnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactServices_Contacts_contactId",
                table: "ContactServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactServices_Services_idService",
                table: "ContactServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactServices",
                table: "ContactServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactFurnitures",
                table: "ContactFurnitures");

            migrationBuilder.DropColumn(
                name: "dvt",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "oldNumber",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "priceService",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "note",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "birthOfDay",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "contractEndDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "dateRange",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "depositAmount",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "depositDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "idRoom",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "identification",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "issuedBy",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "note",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "numberOfPeople",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "numberOfVehicle",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "permanentAddress",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "rentalStartDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "rentalTerm",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "retailPrice",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "signature",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "ContactServices",
                newName: "ContactService");

            migrationBuilder.RenameTable(
                name: "ContactFurnitures",
                newName: "ContactFurniture");

            migrationBuilder.RenameIndex(
                name: "IX_ContactServices_idService",
                table: "ContactService",
                newName: "IX_ContactService_idService");

            migrationBuilder.RenameIndex(
                name: "IX_ContactFurnitures_idFurniture",
                table: "ContactFurniture",
                newName: "IX_ContactFurniture_idFurniture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactService",
                table: "ContactService",
                columns: new[] { "contactId", "idService" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactFurniture",
                table: "ContactFurniture",
                columns: new[] { "contactId", "idFurniture" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactFurniture_Contacts_contactId",
                table: "ContactFurniture",
                column: "contactId",
                principalTable: "Contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactFurniture_Furnitures_idFurniture",
                table: "ContactFurniture",
                column: "idFurniture",
                principalTable: "Furnitures",
                principalColumn: "idFurniture",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactService_Contacts_contactId",
                table: "ContactService",
                column: "contactId",
                principalTable: "Contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactService_Services_idService",
                table: "ContactService",
                column: "idService",
                principalTable: "Services",
                principalColumn: "idService",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
