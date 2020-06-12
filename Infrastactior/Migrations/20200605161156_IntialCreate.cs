using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastactior.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Stret = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PortflioItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortflioItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    addressID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Owners_Address_addressID",
                        column: x => x.addressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "ID", "Avatar", "FullName", "Profile", "addressID" },
                values: new object[] { new Guid("deba0367-8bec-4e64-b362-84936eaadf0d"), "avatar.jpg", "Abdelazeem Mousa", "Microsoft Developer / .NEt", null });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_addressID",
                table: "Owners",
                column: "addressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "PortflioItems");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
