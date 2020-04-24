using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonor.Data.Migrations
{
    public partial class AddBloodLabModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodLabs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    LocationId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodLabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodLabs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodLabs_IsDeleted",
                table: "BloodLabs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BloodLabs_LocationId",
                table: "BloodLabs",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodLabs");
        }
    }
}
