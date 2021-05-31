using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GallaSoft.RetailerOnboardingAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Retailers",
                columns: table => new
                {
                    RetailerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetailerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetDirectory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailers", x => x.RetailerId);
                });

            migrationBuilder.CreateTable(
                name: "StatusMaps",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMaps", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                table: "StatusMaps",
                columns: new[] { "StatusId", "Status" },
                values: new object[] { 1, "Active" });

            migrationBuilder.InsertData(
                table: "StatusMaps",
                columns: new[] { "StatusId", "Status" },
                values: new object[] { 2, "InActive" });

            migrationBuilder.InsertData(
                table: "StatusMaps",
                columns: new[] { "StatusId", "Status" },
                values: new object[] { 3, "Pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Retailers");

            migrationBuilder.DropTable(
                name: "StatusMaps");
        }
    }
}
